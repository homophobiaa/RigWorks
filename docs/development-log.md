# Development log

## 2026-11-15 — Stack initialization

- Initialized the React/TypeScript/Vite SPA and .NET 10 controller API in one
  solution with Domain, Application, Infrastructure and test projects.
- Configured SQL Server/EF Core, Identity stores and an initial Identity migration;
  applied it to the new local RigWorks database. No accounts or roles were seeded.
- Established secure same-origin cookie/CSRF foundations and `/api/auth/me`.
  Added a real API connection preview with loading, anonymous and failure states.
- Generated CSS and Motion tokens from the existing design specification and
  frontend API types from build-time OpenAPI. Added shared EUR/number formatters.
- Added HTTP integration tests, GitHub Actions verification and setup documents.
- Used HTTPS port 7443 for the API after finding Windows reserves port 7080.
- Authentication forms/actions, three-role policies, catalog models, component
  data and compatibility logic remain for subsequent feature work.

Validation: Debug/Release backend builds and four HTTP integration tests passed;
the EF model matches its migration; frontend typecheck, lint, production build,
token verification and generated API types passed. Live HTTPS proxy requests
returned health 200, CSRF 204 with cookies, and anonymous session 401. npm and
NuGet audits reported no known package vulnerabilities. GitHub Actions is
configured but has not run remotely. Visual browser QA was blocked by the local
self-signed Vite certificate; responsive and keyboard behavior need that review.
