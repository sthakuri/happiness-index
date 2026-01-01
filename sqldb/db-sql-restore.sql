/* =========================================================
   1. Restore HappyDb if it does not exist
   ========================================================= */

IF DB_ID('HappyDb') IS NULL
BEGIN
    PRINT 'Restoring HappyDb...';

    RESTORE DATABASE HappyDb
    FROM DISK = '/var/opt/mssql/backup/HappyDb.bak'
    WITH
        MOVE 'HappyDb'     TO '/var/opt/mssql/data/HappyDb.mdf',
        MOVE 'HappyDb_log' TO '/var/opt/mssql/data/HappyDb_log.ldf',
        REPLACE;

    PRINT 'HappyDb restored.';
END
ELSE
BEGIN
    PRINT 'HappyDb already exists. Skipping restore.';
END
GO

/* =========================================================
   2. Create application LOGIN (server-level)
   ========================================================= */

IF NOT EXISTS (
    SELECT 1 FROM sys.sql_logins WHERE name = 'happy_app_user'
)
BEGIN
    PRINT 'Creating SQL login happy_app_user...';

    CREATE LOGIN happy_app_user
    WITH PASSWORD = 'HappyApp@123',
         CHECK_POLICY = ON;
END
ELSE
BEGIN
    PRINT 'SQL login happy_app_user already exists.';
END
GO

/* =========================================================
   3. Create USER in HappyDb and grant permissions
   ========================================================= */

USE HappyDb;
GO

IF NOT EXISTS (
    SELECT 1 FROM sys.database_principals WHERE name = 'happy_app_user'
)
BEGIN
    PRINT 'Creating database user happy_app_user...';

    CREATE USER happy_app_user FOR LOGIN happy_app_user;

    -- DEV / TEST (full access)
    ALTER ROLE db_owner ADD MEMBER happy_app_user;

    -- PROD alternative (comment db_owner, use below instead)
    -- ALTER ROLE db_datareader ADD MEMBER happy_app_user;
    -- ALTER ROLE db_datawriter ADD MEMBER happy_app_user;
END
ELSE
BEGIN
    PRINT 'Database user happy_app_user already exists.';
END
GO

/* =========================================================
   4. Ensure database is ONLINE
   ========================================================= */

ALTER DATABASE HappyDb SET ONLINE;
GO
