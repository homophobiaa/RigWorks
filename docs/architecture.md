# Architecture

RigWorks is a modular monolith with a separate client-rendered SPA.

- `frontend/`: React, strict TypeScript and Vite. CSS Modules and generated CSS
  custom properties implement `.claude/DESIGN.md`. Motion for React respects the
  user's reduced-motion preference. Unstyled Radix primitives will be installed
  when a component first needs one.
- `RigWorks.Domain`: independent business model and rules. Contains `Brand`,
  `Component`, `PcBuild` and `ComponentCategory`; no EF Core or Identity dependency.
- `RigWorks.Application`: use cases and abstractions; references Domain.
- `RigWorks.Infrastructure`: SQL Server persistence and Identity; references
  Application and transitively Domain. Identity users stay outside Domain.
- `RigWorks.Api`: controllers, HTTP contracts, security and composition;
  references Application and Infrastructure.
- `RigWorks.Tests`: tests the real HTTP pipeline with an in-process test server.

The backend targets .NET 10. EF Core and Identity package/tool versions are pinned.
The Node dependency graph is locked in `frontend/package-lock.json`.

TypeScript stays on 5.9 because the chosen OpenAPI generator declares TypeScript
5.x peer support. The lint parser's minimatch dependency is overridden to the
patched 11.x line to address its glob-pattern denial-of-service advisory; lint
and dependency checks validate the resulting graph.

## HTTP boundary

The browser calls relative `/api` URLs through one `openapi-fetch` client. In
development, HTTPS Vite proxies those requests to HTTPS Kestrel. Production must
also expose both under the same site; hosting remains undecided.

`Microsoft.AspNetCore.OpenApi` describes the controllers. The build emits
`artifacts/openapi/RigWorks.Api.json`; `npm run api:generate` turns that document
into the committed `frontend/src/services/api/schema.d.ts`. CI detects drift.

Identity uses secure HttpOnly cookies, SameSite=Lax, sliding expiration and 401/403
responses instead of login redirects. MVC globally validates antiforgery tokens
on unsafe methods. ViewFeatures is registered solely to supply MVC's built-in
antiforgery filter; the application serves no Razor UI.

`GET /api/auth/csrf` bootstraps a readable `XSRF-TOKEN` cookie. The shared client
sends its value as `X-XSRF-TOKEN` for mutations. Future authentication actions must
refresh this token after the authenticated identity changes. `GET /api/auth/me`
returns 401 to anonymous visitors. Registration, sign-in/out and role policies are
future work; no accounts or role names have been seeded.

`GET /api/health` is process liveness only. It deliberately does not test database
readiness. Neither builds nor HTTP foundation tests require a running database.
Migrations are applied explicitly with the EF tool, never automatically on boot.

## Next implementation decisions

The planned roles are `User`, `CatalogEditor`, and `Admin`; confirm permissions
before implementing authorization policies or seeding roles. Expand the initial
catalog/build schema with specifications and selected components in later
migrations. Compatibility remains deterministic and server-authoritative;
unknown data must remain unknown. No product specifications or prices are seeded.

See [the initial database schema](database.md) for entities, relationships and
verification commands.
