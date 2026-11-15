# Initial database — assignment 4.1

The assignment's first stage asks for a designed and created initial database;
the complete final schema belongs to later stages. This foundation uses the
existing .NET 10 / EF Core 10 SQL Server provider, Identity stores and single
`RigWorksDbContext` in Infrastructure. No package changes are needed.

## Tables and relationships

| Table | Initial columns | Constraints and indexes |
| --- | --- | --- |
| `Brands` | `Id int IDENTITY`, `Name nvarchar(100)` | Required, nonblank unique name; primary key on Id |
| `Components` | `Id int IDENTITY`, `Name nvarchar(200)`, `BrandId int`, `Category varchar(32)`, `Price decimal(18,2) NULL` | Required nonblank name, required brand FK, allowed-category check, non-negative or NULL price; indexes on BrandId and Category |
| `PcBuilds` | `Id int IDENTITY`, `Name nvarchar(100)`, `UserId nvarchar(450)`, `Budget decimal(18,2) NULL` | Required nonblank name and user FK; non-negative or NULL budget; index on UserId |

All fields except Price and Budget are required. Currency is EUR. NULL price is
unknown; zero is an explicitly entered zero price. NULL budget means no spending
limit was specified. There are no monetary defaults.

Component categories are `Cpu`, `Gpu`, `Motherboard`, `Memory`, `Storage`,
`PowerSupply`, `Case` and `Cooling`. They are a Domain enum stored as readable
strings. Adding/renaming a category requires a migration updating its check.

Brand has many components; each component has one brand. Deleting a brand with
components is restricted. Users have many builds; each build has one Identity
user. Deleting a user who owns builds is restricted. Later delete/account-removal
workflows must deliberately handle dependents before removing these principals.

Domain holds POCO entities and the category enum. Infrastructure holds all EF
configurations and the Identity relationship. `PcBuild.UserId` stays a plain
string in Domain; `ApplicationUser.Builds` supplies the Identity-side navigation
without adding a database column or a Domain dependency on Identity.

Identity's existing tables are reused: `AspNetUsers`, `AspNetRoles`,
`AspNetUserRoles`, `AspNetUserClaims`, `AspNetUserLogins`, `AspNetUserTokens` and
`AspNetRoleClaims`. They support the planned User, CatalogEditor and Admin roles;
no role rows, permission policies or users are seeded by this migration.

## Migration history and local configuration

`20261115200111_InitialIdentity` was already committed, pushed and applied before
this task. It remains unchanged. The new `InitialCreate` migration adds the three
domain tables and preserves the existing Identity tables and data. A fresh
database applies both migrations in order; an existing database applies only the
new migration. `__EFMigrationsHistory` records the applied versions.

The established connection key is `ConnectionStrings:RigWorks`. Local
configuration stays in .NET user-secrets, using the approved SQL Server Express
instance and RigWorks database. No connection string or credentials are added to
application settings. Migrations are never automatically applied at startup.

```powershell
dotnet restore RigWorks.sln
dotnet build RigWorks.sln --configuration Release
dotnet ef dbcontext list --project backend/RigWorks.Infrastructure --startup-project backend/RigWorks.Api --configuration Release --no-build
dotnet ef database update --project backend/RigWorks.Infrastructure --startup-project backend/RigWorks.Api --configuration Release --no-build
dotnet ef migrations has-pending-model-changes --project backend/RigWorks.Infrastructure --startup-project backend/RigWorks.Api --configuration Release --no-build
dotnet test RigWorks.sln --configuration Release --no-build
```

Release configuration also avoids file locks from a running Debug preview. See
[local development](development.md) for the existing user-secrets setup.

## Verify against SQL Server

```powershell
sqlcmd -S '.\SQLEXPRESS' -E -C -d RigWorks -b -i scripts/verify-database.sql
```

The script checks nullable EUR amounts, decimal round trips, non-negative amount
constraints, unique/nonblank brand names, allowed categories, required foreign
keys and restrictive deletes. It uses fictional rows in a transaction and rolls
them back on success or failure; it leaves no test users, brands, components or
builds. SQL identity counters can advance during rolled-back inserts.

The independent HTTP foundation tests remain database-free. SQL verification
requires a running local instance with the migrations applied; CI's existing EF
model check does not claim to run these SQL Server behavior checks.

## Deliberately deferred

There is no BuildComponents association, hardware specification table,
compatibility logic, catalog data import, CRUD API, registration/sign-in workflow,
frontend feature or permissions system. Existing `/api/auth/me` and CSRF
foundation endpoints are unchanged. Builds are initial records with ownership
and an optional budget; selection of components will be introduced later.
