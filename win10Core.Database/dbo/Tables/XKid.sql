CREATE TABLE [dbo].[XKid] (
    [KidID]    INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NULL,
    [Email]    VARCHAR (50) NULL,
    [FamilyID] INT          NULL,
    CONSTRAINT [PK_XKid] PRIMARY KEY CLUSTERED ([KidID] ASC)
);

