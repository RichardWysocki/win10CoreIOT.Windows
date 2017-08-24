CREATE TABLE [dbo].[Kid] (
    [KidID]    INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NULL,
    [Email]    VARCHAR (50) NULL,
    [FamilyID] INT          NULL,
    CONSTRAINT [PK_Kid] PRIMARY KEY CLUSTERED ([KidID] ASC)
);

