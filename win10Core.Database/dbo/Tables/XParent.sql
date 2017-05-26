CREATE TABLE [dbo].[XParent] (
    [ParentID] INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NULL,
    [Email]    VARCHAR (50) NULL,
    [FamilyID] INT          NULL,
    CONSTRAINT [PK_XParent] PRIMARY KEY CLUSTERED ([ParentID] ASC),
    CONSTRAINT [FK_XParent_XFamily] FOREIGN KEY ([FamilyID]) REFERENCES [dbo].[XFamily] ([FamilyID])
);

