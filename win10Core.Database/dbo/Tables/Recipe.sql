CREATE TABLE [dbo].[Recipe] (
    [RecipeItemID]              INT           IDENTITY (1, 1) NOT NULL,
    [RecipeItemName]            VARCHAR (50)  NULL,
    [RecipeItemNameDescription] VARCHAR (100) NULL,
    [MenuGroupID]               INT           NULL,
    CONSTRAINT [PK_Recipe] PRIMARY KEY CLUSTERED ([RecipeItemID] ASC)
);

