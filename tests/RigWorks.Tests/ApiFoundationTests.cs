using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace RigWorks.Tests;

public sealed class ApiFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Development");
        // Verify these endpoints work even on a machine with no database secret.
        builder.ConfigureAppConfiguration((_, configuration) =>
            configuration.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["ConnectionStrings:RigWorks"] = null
            }));
        builder.ConfigureServices(services => services.AddControllers()
            .AddApplicationPart(typeof(AntiforgeryProbeController).Assembly));
    }
}

public sealed class ApiFoundationTests(ApiFactory factory) : IClassFixture<ApiFactory>
{
    private HttpClient CreateClient() => factory.CreateClient(new WebApplicationFactoryClientOptions
    {
        BaseAddress = new Uri("https://localhost"),
        AllowAutoRedirect = false
    });

    [Fact]
    public async Task Health_is_live_without_using_the_database()
    {
        using var client = CreateClient();
        var response = await client.GetFromJsonAsync<JsonElement>("/api/health");
        Assert.Equal("Running", response.GetProperty("status").GetString());
    }

    [Fact]
    public async Task Anonymous_session_returns_401_without_redirecting()
    {
        using var client = CreateClient();
        using var response = await client.GetAsync("/api/auth/me");
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        Assert.Null(response.Headers.Location);
    }

    [Fact]
    public async Task OpenApi_describes_the_foundation_endpoints()
    {
        using var client = CreateClient();
        var document = await client.GetFromJsonAsync<JsonElement>("/api/openapi/v1.json");
        var paths = document.GetProperty("paths");
        Assert.True(paths.TryGetProperty("/api/health", out _));
        Assert.True(paths.TryGetProperty("/api/auth/csrf", out _));
        Assert.True(paths.TryGetProperty("/api/auth/me", out _));
    }

    [Fact]
    public async Task Mutation_requires_matching_antiforgery_cookie_and_header()
    {
        using var client = CreateClient();
        using var rejected = await client.PostAsync("/test/antiforgery", null);
        Assert.Equal(HttpStatusCode.BadRequest, rejected.StatusCode);

        using var initialization = await client.GetAsync("/api/auth/csrf");
        Assert.Equal(HttpStatusCode.NoContent, initialization.StatusCode);
        var cookies = initialization.Headers.GetValues("Set-Cookie").ToArray();
        var requestCookie = Assert.Single(cookies, cookie => cookie.StartsWith("XSRF-TOKEN="));
        Assert.Contains("secure", requestCookie, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("samesite=lax", requestCookie, StringComparison.OrdinalIgnoreCase);
        Assert.DoesNotContain("httponly", requestCookie, StringComparison.OrdinalIgnoreCase);
        var privateCookie = Assert.Single(cookies, cookie => cookie.StartsWith("RigWorks.Antiforgery="));
        Assert.Contains("httponly", privateCookie, StringComparison.OrdinalIgnoreCase);

        var token = Uri.UnescapeDataString(requestCookie.Split(';')[0]["XSRF-TOKEN=".Length..]);
        client.DefaultRequestHeaders.Add("X-XSRF-TOKEN", token);
        using var accepted = await client.PostAsync("/test/antiforgery", null);
        Assert.Equal(HttpStatusCode.NoContent, accepted.StatusCode);

        client.DefaultRequestHeaders.Remove("X-XSRF-TOKEN");
        client.DefaultRequestHeaders.Add("X-XSRF-TOKEN", "invalid-token");
        using var tampered = await client.PostAsync("/test/antiforgery", null);
        Assert.Equal(HttpStatusCode.BadRequest, tampered.StatusCode);
    }
}

// Only registered by the test host, never part of the production API.
[ApiController]
[AllowAnonymous]
[ApiExplorerSettings(IgnoreApi = true)]
[Route("test/antiforgery")]
public sealed class AntiforgeryProbeController : ControllerBase
{
    [HttpPost]
    public IActionResult Post() => NoContent();
}
