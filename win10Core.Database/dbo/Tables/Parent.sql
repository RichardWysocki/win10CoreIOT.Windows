CREATE TABLE [dbo].[Parent] (
    [ParentId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (100) NULL,
    [Email]    VARCHAR (100) NULL,
    [FamilyId] INT           NOT NULL,
    CONSTRAINT [PK_Parent] PRIMARY KEY CLUSTERED ([ParentId] ASC),
    CONSTRAINT [FK_Parent_Family] FOREIGN KEY ([FamilyId]) REFERENCES [dbo].[Family] ([FamilyId])
);

