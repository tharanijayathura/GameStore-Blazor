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
CREATE TABLE [Genres] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Genres] PRIMARY KEY ([Id])
);

CREATE TABLE [Games] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [GenreId] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [ReleaseDate] date NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Games_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Genres]'))
    SET IDENTITY_INSERT [Genres] ON;
INSERT INTO [Genres] ([Id], [Name])
VALUES (1, N'Fighting'),
(2, N'Roleplaying'),
(3, N'Sports'),
(4, N'Racing'),
(5, N'Kids and Family'),
(6, N'Adventure'),
(7, N'Sandbox');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Genres]'))
    SET IDENTITY_INSERT [Genres] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'GenreId', N'Name', N'Price', N'ReleaseDate', N'UpdatedAt') AND [object_id] = OBJECT_ID(N'[Games]'))
    SET IDENTITY_INSERT [Games] ON;
INSERT INTO [Games] ([Id], [CreatedAt], [GenreId], [Name], [Price], [ReleaseDate], [UpdatedAt])
VALUES (1, '2025-10-09T16:28:58.8986383Z', 1, N'Street Fighter II', 19.99, '2017-03-03', '2025-10-09T16:28:58.8986721Z'),
(2, '2025-10-09T16:28:58.8987019Z', 6, N'The Zelda', 29.99, '1998-11-21', '2025-10-09T16:28:58.8987020Z'),
(3, '2025-10-09T16:28:58.8987024Z', 7, N'Minecraft', 26.95, '2011-11-18', '2025-10-09T16:28:58.8987025Z');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'GenreId', N'Name', N'Price', N'ReleaseDate', N'UpdatedAt') AND [object_id] = OBJECT_ID(N'[Games]'))
    SET IDENTITY_INSERT [Games] OFF;

CREATE INDEX [IX_Games_GenreId] ON [Games] ([GenreId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251009162859_InitialCreate', N'9.0.0');

COMMIT;
GO