# Development log

## 2026-11-16 — Design specification v2.0

- Adopted the user's v2.0 design specification and its new test bench; moved the
  original v1.1 bench into `docs/Design Tech Bench's/` alongside it.
- Regenerated CSS tokens for the lime/graphite palette and provisional Archivo
  typography. Mapped Archivo to the specified display-font fallback stack.
- Updated the existing preview button's hover state to use the new primary-hover
  token and aligned browser theme metadata with the new canvas colour.
- Token consistency, frontend lint, typecheck and production build passed. The
  provisional brand lockup and full visual implementation remain future work.

## 2026-11-15 — Initial domain database for assignment 4.1

- Read the stage 4.1 instructions and reconstructed individual diploma assignment;
  kept this task limited to the initial database foundation.
- Reused the single SQL Server/Identity context, role stores, DI and user-secret
  configuration. Preserved the published/applied `InitialIdentity` migration.
- Added Domain entities Brand, Component and PcBuild plus ComponentCategory.
  Domain still has no EF Core or Identity dependency. Added Infrastructure
  configurations, DbSets and the Identity user's collection navigation for builds.
- Added nullable EUR decimal(18,2) amounts, non-negative checks, required/nonblank
  names, a unique brand-name index, category validation and required foreign keys.
  Referenced brands and users with builds cannot be accidentally cascade-deleted.
- Generated and applied `20261115203533_InitialCreate` to the existing local
  RigWorks database. It adds only Brands, Components and PcBuilds; Identity tables
  remain intact. Fresh databases will apply both migrations in sequence.
- Documented the schema and repeatable SQL verification script. Confirmed the
  planned role names User, CatalogEditor and Admin; no users or roles are seeded.
- Restore, Release build (zero warnings/errors), context discovery, model/migration
  consistency and all four existing tests passed. Used Release because the
  running Debug preview held build outputs open.
- Verified real SQL Server tables, columns, primary/foreign keys and indexes.
  Transactional SQL checks passed for NULL/zero/decimal EUR amounts, negative
  amount rejection, unique/nonblank brands, category validation, missing-FK
  rejection and restrictive deletes. All verification fixtures were rolled back;
  no users, roles, brands, components or builds remain in the local database.
- No frontend/API feature, authentication workflow, role policy, selected-component
  association, specifications, compatibility rule or catalog seed was added.
  The database implementation and its verification/documentation are grouped
  separately for the commit and push requested on 2026-11-16.

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
