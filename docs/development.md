# Local development

Run commands from the repository root unless a section says otherwise.

## Prerequisites

- .NET 10 SDK compatible with `global.json`.
- Node.js 22.12+ on the 22 line, or Node.js 24+; npm.
- SQL Server Express with Windows authentication for the approved Windows setup.

Approved addresses: SPA `https://localhost:5173`, API `https://localhost:7443`.
Approved local SQL instance: `.\SQLEXPRESS`; database: `RigWorks`.

Port 7080 was initially proposed but falls in a Windows-reserved TCP range on the
development machine; the API and proxy therefore use 7443.

## First setup

```powershell
dotnet tool restore
dotnet dev-certs https --trust
dotnet user-secrets set "ConnectionStrings:RigWorks" "<your local SQL Server connection string>" --project backend/RigWorks.Api
dotnet ef database update --project backend/RigWorks.Infrastructure --startup-project backend/RigWorks.Api
dotnet build RigWorks.sln
cd frontend
npm ci
npm run api:generate
```

Use Windows integrated authentication, encryption, and the approved server and
database in the connection string. Trusting the local server certificate is
acceptable for this development instance. Store connection strings only in
user-secrets; never commit credentials or add them to frontend environment files.

The current machine's user-secret was configured during initialization. The
database includes the Identity migration and the `InitialCreate` domain migration.
Other machines need the first-setup steps. See [database schema and verification](database.md).

## Run

Backend terminal:

```powershell
dotnet watch --project backend/RigWorks.Api --launch-profile https
```

Frontend terminal:

```powershell
cd frontend
npm run dev
```

Open `https://localhost:5173`. Vite generates its own local self-signed development
certificate with `@vitejs/plugin-basic-ssl`; accept that certificate for localhost
if the browser prompts. The API uses the ASP.NET development certificate. Vite's
proxy accepts that local API certificate; this setting is development-only.

The development preview shows the actual API connection and anonymous session,
initializes CSRF protection, and offers a working connection check. An API outage
shows an explicit error. It is an initialization screen, not the finished product.

## Verify

```powershell
dotnet build RigWorks.sln --configuration Release
dotnet test RigWorks.sln --configuration Release --no-build
dotnet ef migrations has-pending-model-changes --project backend/RigWorks.Infrastructure --startup-project backend/RigWorks.Api
cd frontend
npm run api:generate
npm run tokens:check
npm run lint
npm run build
```

Backend tests cover liveness, anonymous 401 responses, OpenAPI endpoints, and
acceptance/rejection of matching, missing and tampered CSRF tokens. The mutation
probe exists only in the test host. Tests never create users or modify SQL data.

After changing API contracts, build the backend, regenerate API types, and commit
the updated generated declaration. After an approved design change, run
`npm run tokens:generate`; generated CSS and Motion tokens come from the YAML in
`.claude/DESIGN.md`. CI checks that these files match their source.

For a model change, generate and inspect a migration before applying it:

```powershell
dotnet ef migrations add <Name> --project backend/RigWorks.Infrastructure --startup-project backend/RigWorks.Api --output-dir Data/Migrations
dotnet ef database update --project backend/RigWorks.Infrastructure --startup-project backend/RigWorks.Api
```
