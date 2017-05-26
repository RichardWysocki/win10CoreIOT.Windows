CREATE TABLE [dbo].[RecipeNutritional] (
    [RecipeNutritionalID]          INT           IDENTITY (1, 1) NOT NULL,
    [RecipeName]                   VARCHAR (50)  NULL,
    [RecipeItemServingDescription] VARCHAR (100) NULL,
    [RecipeItemDescription]        VARCHAR (100) NULL,
    [RecipeItemCalories]           VARCHAR (100) NULL,
    [RecipeItemTotalFat]           VARCHAR (100) NULL,
    [RecipeItemCholesterol]        VARCHAR (100) NULL,
    [RecipeItemSodium]             VARCHAR (100) NULL,
    [RecipeItemPotassium]          VARCHAR (100) NULL,
    [RecipeItemTotalCarbohydrate]  VARCHAR (100) NULL,
    [RecipeItemProtein]            VARCHAR (100) NULL,
    [RecipeItemID]                 INT           NULL,
    CONSTRAINT [PK_RecipeNutritional] PRIMARY KEY CLUSTERED ([RecipeNutritionalID] ASC)
);

