CREATE TABLE [dbo].[XFamily] (
    [FamilyID] INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NULL,
    CONSTRAINT [PK_XFamily] PRIMARY KEY CLUSTERED ([FamilyID] ASC)
);

