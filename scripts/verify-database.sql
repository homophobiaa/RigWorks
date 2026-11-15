-- Run after database update with: sqlcmd -S <server> -E -C -d RigWorks -b -i scripts/verify-database.sql
-- Fictional verification rows are always rolled back; no catalog/account seed data remains.
SET NOCOUNT ON;
-- Identity has filtered indexes, which require these session options.
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET NUMERIC_ROUNDABORT OFF;
SET XACT_ABORT OFF;

BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @Suffix nvarchar(36) = CONVERT(nvarchar(36), NEWID());
    DECLARE @BrandName nvarchar(100) = N'Sample verification brand ' + @Suffix;
    DECLARE @UserId nvarchar(450) = N'verification-' + @Suffix;
    DECLARE @MissingUserId nvarchar(450) = N'missing-' + @Suffix;
    DECLARE @BrandId int, @ComponentId int, @BuildId int;

    INSERT dbo.Brands (Name) VALUES (@BrandName);
    SET @BrandId = SCOPE_IDENTITY();

    INSERT dbo.Components (Name, BrandId, Category, Price)
    VALUES (N'Sample component A', @BrandId, 'Cpu', NULL);
    SET @ComponentId = SCOPE_IDENTITY();
    IF NOT EXISTS (SELECT 1 FROM dbo.Components WHERE Id = @ComponentId AND Price IS NULL)
        THROW 50001, 'Unknown component prices must remain NULL.', 1;

    UPDATE dbo.Components SET Price = 123.45 WHERE Id = @ComponentId;
    IF NOT EXISTS (SELECT 1 FROM dbo.Components WHERE Id = @ComponentId AND Price = 123.45)
        THROW 50002, 'EUR prices must preserve two decimal places.', 1;
    UPDATE dbo.Components SET Price = 0 WHERE Id = @ComponentId;

    -- Persistence fixture only; this is not a registered/login-capable account.
    INSERT dbo.AspNetUsers (Id, UserName, NormalizedUserName, EmailConfirmed,
        PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount)
    VALUES (@UserId, @UserId, UPPER(@UserId), 0, 0, 0, 1, 0);

    INSERT dbo.PcBuilds (Name, UserId, Budget)
    VALUES (N'Sample build A', @UserId, NULL);
    SET @BuildId = SCOPE_IDENTITY();
    IF NOT EXISTS (SELECT 1 FROM dbo.PcBuilds WHERE Id = @BuildId AND Budget IS NULL)
        THROW 50003, 'An unspecified budget must remain NULL.', 1;
    UPDATE dbo.PcBuilds SET Budget = 1500.99 WHERE Id = @BuildId;
    IF NOT EXISTS (SELECT 1 FROM dbo.PcBuilds WHERE Id = @BuildId AND Budget = 1500.99)
        THROW 50004, 'EUR budgets must preserve two decimal places.', 1;
    UPDATE dbo.PcBuilds SET Budget = 0 WHERE Id = @BuildId;

    BEGIN TRY
        INSERT dbo.Brands (Name) VALUES (@BrandName);
        THROW 50010, 'Duplicate brand names were accepted.', 1;
    END TRY
    BEGIN CATCH
        IF ERROR_NUMBER() NOT IN (2601, 2627) THROW;
    END CATCH;

    BEGIN TRY
        UPDATE dbo.Brands SET Name = N'   ' WHERE Id = @BrandId;
        THROW 50011, 'Blank brand names were accepted.', 1;
    END TRY
    BEGIN CATCH
        IF ERROR_NUMBER() <> 547 THROW;
    END CATCH;

    BEGIN TRY
        UPDATE dbo.Components SET Price = -0.01 WHERE Id = @ComponentId;
        THROW 50012, 'Negative component prices were accepted.', 1;
    END TRY
    BEGIN CATCH
        IF ERROR_NUMBER() <> 547 THROW;
    END CATCH;

    BEGIN TRY
        UPDATE dbo.PcBuilds SET Budget = -0.01 WHERE Id = @BuildId;
        THROW 50013, 'Negative budgets were accepted.', 1;
    END TRY
    BEGIN CATCH
        IF ERROR_NUMBER() <> 547 THROW;
    END CATCH;

    BEGIN TRY
        UPDATE dbo.Components SET Category = 'InvalidCategory' WHERE Id = @ComponentId;
        THROW 50014, 'Invalid component categories were accepted.', 1;
    END TRY
    BEGIN CATCH
        IF ERROR_NUMBER() <> 547 THROW;
    END CATCH;

    BEGIN TRY
        UPDATE dbo.Components SET BrandId = -2147483648 WHERE Id = @ComponentId;
        THROW 50015, 'A component with a missing brand was accepted.', 1;
    END TRY
    BEGIN CATCH
        IF ERROR_NUMBER() <> 547 THROW;
    END CATCH;

    BEGIN TRY
        UPDATE dbo.PcBuilds SET UserId = @MissingUserId WHERE Id = @BuildId;
        THROW 50016, 'A build with a missing user was accepted.', 1;
    END TRY
    BEGIN CATCH
        IF ERROR_NUMBER() <> 547 THROW;
    END CATCH;

    BEGIN TRY
        DELETE dbo.Brands WHERE Id = @BrandId;
        THROW 50017, 'Deleting a referenced brand was allowed.', 1;
    END TRY
    BEGIN CATCH
        IF ERROR_NUMBER() <> 547 THROW;
    END CATCH;

    BEGIN TRY
        DELETE dbo.AspNetUsers WHERE Id = @UserId;
        THROW 50018, 'Deleting a user who owns builds was allowed.', 1;
    END TRY
    BEGIN CATCH
        IF ERROR_NUMBER() <> 547 THROW;
    END CATCH;

    ROLLBACK TRANSACTION;
    PRINT 'PASS: nullable EUR money, precision, non-negative amounts, category checks, unique brands, foreign keys and restrictive deletes.';
    PRINT 'All fictional verification rows were rolled back.';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    THROW;
END CATCH;
