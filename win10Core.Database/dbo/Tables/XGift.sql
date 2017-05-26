CREATE TABLE [dbo].[XGift] (
    [GiftID]              INT           IDENTITY (1, 1) NOT NULL,
    [KidID]               INT           NULL,
    [Year]                VARCHAR (4)   NULL,
    [Item]                VARCHAR (50)  NULL,
    [Link]                VARCHAR (200) NULL,
    [EstimatedCost]       MONEY         NULL,
    [Wish]                BIT           NULL,
    [Purchased]           BIT           NULL,
    [Recieved]            BIT           NULL,
    [PurchasedByParentID] INT           NULL,
    CONSTRAINT [PK_XGift] PRIMARY KEY CLUSTERED ([GiftID] ASC)
);

