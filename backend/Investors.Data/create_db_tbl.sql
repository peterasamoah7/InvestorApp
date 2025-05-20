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

CREATE TABLE [AssetClass] (
    [AssetClassID] int NOT NULL IDENTITY,
    [Name] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AssetClass] PRIMARY KEY ([AssetClassID])
);
GO

CREATE TABLE [Country] (
    [CountryID] int NOT NULL IDENTITY,
    [Name] nvarchar(450) NULL,
    CONSTRAINT [PK_Country] PRIMARY KEY ([CountryID])
);
GO

CREATE TABLE [InvestorType] (
    [InvestorTypeID] int NOT NULL IDENTITY,
    [TypeOfInvestor] nvarchar(450) NULL,
    CONSTRAINT [PK_InvestorType] PRIMARY KEY ([InvestorTypeID])
);
GO

CREATE TABLE [Investor] (
    [InvestorID] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [DateAdded] datetime2 NOT NULL,
    [DateUpdated] datetime2 NULL,
    [InvestorTypeID] int NULL,
    [CountryID] int NULL,
    CONSTRAINT [PK_Investor] PRIMARY KEY ([InvestorID]),
    CONSTRAINT [FK_Investor_Country_CountryID] FOREIGN KEY ([CountryID]) REFERENCES [Country] ([CountryID]),
    CONSTRAINT [FK_Investor_InvestorType_InvestorTypeID] FOREIGN KEY ([InvestorTypeID]) REFERENCES [InvestorType] ([InvestorTypeID])
);
GO

CREATE TABLE [Commitment] (
    [CommitmentID] int NOT NULL IDENTITY,
    [Amount] decimal(18,2) NOT NULL,
    [Currency] nvarchar(max) NOT NULL,
    [AssetClassID] int NULL,
    [InvestorID] int NOT NULL,
    CONSTRAINT [PK_Commitment] PRIMARY KEY ([CommitmentID]),
    CONSTRAINT [FK_Commitment_AssetClass_AssetClassID] FOREIGN KEY ([AssetClassID]) REFERENCES [AssetClass] ([AssetClassID]),
    CONSTRAINT [FK_Commitment_Investor_InvestorID] FOREIGN KEY ([InvestorID]) REFERENCES [Investor] ([InvestorID]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_AssetClass_Name] ON [AssetClass] ([Name]);
GO

CREATE INDEX [IX_Commitment_AssetClassID] ON [Commitment] ([AssetClassID]);
GO

CREATE INDEX [IX_Commitment_InvestorID] ON [Commitment] ([InvestorID]);
GO

CREATE UNIQUE INDEX [IX_Country_Name] ON [Country] ([Name]) WHERE [Name] IS NOT NULL;
GO

CREATE INDEX [IX_Investor_CountryID] ON [Investor] ([CountryID]);
GO

CREATE INDEX [IX_Investor_InvestorTypeID] ON [Investor] ([InvestorTypeID]);
GO

CREATE UNIQUE INDEX [IX_InvestorType_TypeOfInvestor] ON [InvestorType] ([TypeOfInvestor]) WHERE [TypeOfInvestor] IS NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250517153220_Initial', N'8.0.16');
GO

COMMIT;
GO