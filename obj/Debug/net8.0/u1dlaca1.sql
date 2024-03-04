IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NULL,
    [Phone] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NULL,
    [Archived] bit NULL,
    [Created] datetime2 NULL,
    [Updated] nvarchar(max) NULL,
    [Deleted] nvarchar(max) NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Comments] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NOT NULL,
    [ClientId] int NOT NULL,
    [Created] datetime2 NULL,
    [Updated] nvarchar(max) NULL,
    [Deleted] nvarchar(max) NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Comments_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Comments_ClientId] ON [Comments] ([ClientId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240304191742_Initial', N'8.0.2');
GO

COMMIT;
GO

