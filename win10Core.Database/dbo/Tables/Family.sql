CREATE TABLE [dbo].[Family] (
    [FamilyId]    INT           IDENTITY (1, 1) NOT NULL,
    [FamilyName]  VARCHAR (100) NULL,
    [FamilyEmail] VARCHAR (100) NULL,
    CONSTRAINT [PK_Family] PRIMARY KEY CLUSTERED ([FamilyId] ASC)
);

