# RigWorks — Project Instructions

## Purpose

RigWorks is a web-based PC configurator built as a 2026–2027 diploma project at SoftUni Buditel (official topic: “Конфигуратор на персонален компютър”). It is **not an online store**. The primary experience is manually selecting PC components, understanding compatibility, tracking a budget, and saving/comparing builds.

Make the finished product feel like a polished, modern application—not a school-project demo—but prioritize **correct functionality and trustworthy technical information** over decorative complexity.

## Sources of truth

1. **Current user request** defines the task and its scope.
2. **Actual repository code, dependency manifests, and existing tests** define implemented behavior. Inspect before changing anything; do not assume a planned feature already exists.
3. **`DESIGN.md`** is the authority for visual language, UI components, responsive behavior, accessibility, and motion. **Read it before doing frontend/UI work.** Implement its tokens exactly (see Styling). If a needed UI pattern is missing, propose an addition to `DESIGN.md` built from existing tokens instead of inventing values. Do not edit `DESIGN.md` unless asked.
4. **Official diploma assignment and assessment documents**, when present, define academic requirements. Do not invent requirements or claim compliance without evidence.
5. This file defines engineering conventions and product boundaries. Library and architecture choices live here, not in `DESIGN.md`. If documents conflict or a significant decision remains unmade, flag it rather than silently inventing an answer.

## Chosen stack

- **Frontend:** React, strict TypeScript, Vite; a client-rendered SPA, not Razor Pages or an ASP.NET-rendered UI.
- **Language and currency:** UI copy is **English only**; no i18n layer. Prices are in **EUR**. Format every number, price and unit through the shared formatters in `frontend/src/lib/format.ts` (one `Intl.NumberFormat` locale constant), never by string concatenation.
- **Styling:** CSS Modules plus CSS custom properties.
  - `DESIGN.md` tokens are implemented **once**, in `frontend/src/styles/tokens.css`, mirroring `DESIGN.md` names and values exactly.
  - Components reference `var(--…)` only: no hard-coded colours, font sizes, spacing, radii, shadows or timings.
  - No Tailwind, CSS-in-JS, or themed component libraries (MUI, Chakra, Mantine, Bootstrap, shadcn presets): their defaults compete with `DESIGN.md`.
- **Accessible primitives:** Radix UI Primitives (unstyled) for dialog, popover, tooltip, dropdown menu, select, tabs, toggle, checkbox and similar widgets, styled with CSS Modules. Add each primitive when the first component needs it. Do not hand-roll focus trapping, roving focus or listbox keyboard handling.
- **Motion:** CSS transitions for hover, focus, press, colour changes and simple fades. Motion for React (`motion/react`) for coordinated motion: enter/exit with `AnimatePresence`, layout and shared-element transitions, build-summary updates and the finished-build reveal.
  - Wrap the app once in `<MotionConfig reducedMotion="user">`.
  - Mirror `DESIGN.md`'s motion tokens once in `frontend/src/lib/motion.ts` (Motion uses seconds and bezier arrays); never inline durations or easings.
  - Do not add a second animation library or a 3D engine.
- **Backend:** C#, ASP.NET Core Web API (controllers).
- **Database:** SQL Server with Entity Framework Core (code-first migrations).
- **Authentication:** ASP.NET Core Identity with EF Core stores and **cookie authentication**. No JWT or bearer tokens. See Authentication.
- **API contract:** the API publishes an OpenAPI document (ASP.NET Core's built-in `Microsoft.AspNetCore.OpenApi` on .NET 9+, Swashbuckle on .NET 8).
  - Frontend types are generated from it with `openapi-typescript` into `frontend/src/services/api/schema.d.ts`. That file is committed and never hand-edited. Regenerate it in the same change as any endpoint or contract change.
  - All HTTP calls go through one typed client built on `openapi-fetch` in `frontend/src/services/api/`. No `fetch` calls in components.
  - Serialize enums as strings (`JsonStringEnumConverter`) so statuses such as compatibility results become TypeScript string unions.
- **Tests and automation:** .NET automated tests, relevant frontend checks, GitHub Actions CI. Hosting/deployment provider is **not yet fixed**.

Do not substitute PostgreSQL, Next.js, microservices, GraphQL, or another major stack choice without explicit approval. Prefer existing dependencies; justify new ones before adding them.

## Authentication

- **Same-site only.** In development, the Vite dev server proxies `/api` to the backend, so the browser sees one origin. Production must also serve the SPA and API from the same site (one host or a reverse proxy). Do not work around a cross-site setup with credentialed CORS or `SameSite=None` cookies; raise it instead.
- **Cookie:** HttpOnly, Secure, `SameSite=Lax`, sliding expiration.
- **No redirects from the API.** Override Identity's cookie events (`OnRedirectToLogin`, `OnRedirectToAccessDenied`) so API calls return **401** and **403**, never a 302 to a login page.
- **CSRF protection is mandatory with cookie auth.** Use ASP.NET Core antiforgery on every state-changing request (POST, PUT, PATCH, DELETE): issue the request token in a readable `XSRF-TOKEN` cookie, have the shared API client send it as an `X-XSRF-TOKEN` header, and validate it with a global `AutoValidateAntiforgeryToken` filter.
- **Endpoints:** register, sign in, sign out, and `GET /api/auth/me`, which the SPA calls on load to learn the current user and roles. The frontend uses roles only to show or hide UI; the server enforces every permission.
- Use Identity's password hashing, validation and lockout. Never write custom password hashing, bypass authentication, or use admin privileges as a shortcut to make a feature work.

## Repository layout

Use the existing tree. The agreed direction is:

```text
/
├── frontend/
│   ├── public/
│   └── src/
│       ├── assets/
│       ├── components/       # reusable, domain-neutral UI
│       ├── features/         # configurator, catalog, builds, auth, ...
│       ├── hooks/
│       ├── lib/              # format.ts, motion.ts, small utilities
│       ├── pages/
│       ├── services/api/     # generated schema + the one API client
│       └── styles/           # tokens.css, global styles
├── backend/
│   ├── RigWorks.Api/
│   ├── RigWorks.Application/
│   ├── RigWorks.Domain/
│   └── RigWorks.Infrastructure/
├── tests/
│   └── RigWorks.Tests/
├── RigWorks.sln
├── DESIGN.md
└── CLAUDE.md
```

Do not create empty directories, placeholder abstractions, extra projects, or duplicate folders merely to match this diagram. Follow the real repository when it differs; propose structural changes before making disruptive reorganizations.

### Backend boundaries

- **Domain:** core entities, value objects, enums, and domain rules. No HTTP, EF Core, or UI dependencies.
- **Application:** use cases, business logic, compatibility orchestration, validation, and abstractions used by application logic.
- **Infrastructure:** EF Core `DbContext`, Identity stores, SQL Server configuration, migrations, persistence and external-service implementations.
- **Api:** controllers, request/response contracts, authentication setup, dependency injection, and HTTP concerns. Keep controllers thin.
- Dependency direction: Domain is independent; Application depends on Domain; Infrastructure implements interfaces needed by inner layers; Api composes the application. No circular project references.

### Frontend boundaries

- Keep feature-specific state, API calls and components inside the relevant `features/` area when practical.
- Put genuinely reusable UI in `components/`; do not turn it into a dumping ground for configurator-specific code.
- Business-critical compatibility results are authoritative on the server. Frontend checks may improve responsiveness but never replace server validation.
- Prefer small, typed components over huge page files and unnecessary abstractions. Avoid `any` unless justified.

## Product boundaries

Core scope to support incrementally:

- Catalog of PC components with relevant technical specifications and filters.
- Manual build configuration and component selection.
- Deterministic compatibility checks with clear reasons and actionable feedback.
- Build price/budget tracking and estimated power requirements.
- Accounts with appropriate permissions; saving, copying, comparing and sharing builds.
- Administration/catalog management consistent with the required role model.

**Not automatic requirements:** AI-generated builds, FPS predictions, game/workload recommendations, hardware autodetection, 3D PC visualization, real-time retail pricing, localization, checkout or marketplace features. Implement these only when explicitly prioritized; do not build infrastructure for speculative future ideas.

## Catalog data

- Component specifications must be accurate. Real products enter the catalog only through admin entry or an import from a source the user has verified.
- **Never write real product model names with specifications from memory**, including in seed data, tests and fixtures.
- Seed and demo data is either clearly fictional (“Sample GPU A” with made-up values) or verified against the manufacturer's page with the source recorded.
- Do not scrape retail sites or add live price feeds. Prices are entered data, not fetched.

## Compatibility and data integrity

- The backend is the source of truth for compatibility. Use explicit, testable rules based on stored specifications; **never have an AI infer compatibility at runtime**.
- Distinguish **compatible**, **conditional/warning**, **incompatible**, and **not evaluated / insufficient data**. Unknown must never silently become compatible.
- Explain *why* a rule failed, which parts are involved, and what is missing when a rule cannot be evaluated.
- Prioritize CPU/motherboard socket, RAM generation and support, physical clearances, power and PSU connectors, storage interfaces, and other constraints actually supported by the data model.
- Do not claim exact fit, sufficient wattage, expected FPS, market price or manufacturer certification without reliable inputs. Label estimates and assumptions as such.
- Use consistent units and explicit conversions; store numerical specifications in unambiguous forms. Do not conflate nominal PSU wattage with predicted system draw.
- Missing prices are **unknown**, not zero. Distinguish partial totals from complete totals, and keep budget alerts separate from hardware incompatibility.
- Validate API inputs and enforce invariants server-side, including authorization and ownership checks. Do not trust client-provided prices or compatibility statuses.

## Academic and implementation requirements

- Preserve the assigned **three-role** authorization requirement; planned role names confirmed by the user are `User`, `CatalogEditor`, and `Admin`. Identity stores support them; permissions, policies and role seeding are deferred until their implementation task.
- The final solution must demonstrate at least five meaningful entities/models, views or screens, and controllers/endpoints as required by the official documents. Do not create fake entities to inflate counts.
- Use a genuine, explainable design pattern where it improves the implementation; do not add patterns or layers for decoration.
- Maintain meaningful automated tests of business logic, especially compatibility rules, unknown-data handling, budgets, and permissions. Follow any documented coverage threshold; verify the report before claiming it was achieved.
- School stages are milestones, not instructions to build the entire final product at once. Deliver working, integrated slices rather than unrelated scaffolding.

## Engineering workflow

1. **Inspect first:** read the affected code, nearby conventions, manifests, migrations, and tests. For visual tasks, read `DESIGN.md`. Check `git status` before editing; never overwrite uncommitted work.
2. **Scope:** for multi-file or architectural changes, state a brief plan and acceptance criteria. Do not turn a focused request into an unsolicited rewrite.
3. **Implement end-to-end:** prefer a working vertical slice over mock pages, fake data or dead buttons. Temporary stubs must be explicit and must not look like finished features.
4. **Verify:** run the relevant builds, typechecks, linting and tests; for UI, check responsive layouts and keyboard interaction where practical.
5. **Report:** summarize changes, checks actually run, unresolved problems and manual steps. State clearly when a check could not run.

### Local development

Local settings approved on 2026-11-15: Vite at `https://localhost:5173`, API at `https://localhost:7443`, and SQL Server Express (`.\SQLEXPRESS`) using Windows authentication with a `RigWorks` development database. The connection key is `ConnectionStrings:RigWorks`, stored in .NET user-secrets, never in committed `appsettings` files. See `docs/development.md` for setup and commands. The authoritative instruction and design files remain in `.claude/`; the layout above is illustrative.

### Common checks (verify files/scripts exist first)

- Backend build: `dotnet build RigWorks.sln`
- Backend tests: `dotnet test RigWorks.sln`
- Frontend: the existing `frontend/package.json` scripts, using the package manager indicated by the lockfile.
- Database: use checked-in EF Core migrations. Inspect migration impact before applying; never drop or reset data casually.

Do not claim a command is configured or passing until verified in the current repository.

## Change safety

- Keep secrets, credentials and connection strings out of committed files; maintain safe example config instead.
- Commit EF Core migrations alongside the model changes that produce them. No destructive data migrations without explicit approval.
- Do not silently upgrade major dependencies, switch database providers, change the auth strategy, restructure the solution, or deploy production changes.
- No automatic commits, pushes, force-pushes or destructive Git operations unless requested.

## UI quality bar

- Implement the **complete interaction**, not just an attractive screenshot: every applicable state defined in `DESIGN.md`'s interaction-state model, plus loading, empty and error states.
- Animation must communicate state or mark a deliberate showcase moment; it never delays price or compatibility feedback.
- Treat mobile and desktop as real layouts rather than relying on horizontal overflow, except where an intentionally scrollable comparison table requires it.

## Git and delivery

- Current workflow: direct, sensible commits to `main` when **the user asks for a commit**. No mandatory feature branch, PR, or production branch at this stage.
- Use concise conventional commit messages (`feat:`, `fix:`, `refactor:`, `test:`, `docs:`).
- CI builds and tests on pushes as configured. Add automatic deployment only after hosting is selected and configured.
- Never claim a feature, coverage target, staging environment, or production deployment exists unless it has been verified.
