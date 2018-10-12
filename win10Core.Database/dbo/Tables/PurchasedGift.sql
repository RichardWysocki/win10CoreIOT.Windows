CREATE TABLE [dbo].[PurchasedGift] (
    [PurchasedGiftID] INT          IDENTITY (1, 1) NOT NULL,
    [GiftID]          INT          NULL,
    [DatePurchased]   BIT          NULL,
    [EmailSent]       BIT          NULL,
    [PurchasedBy]     VARCHAR (50) NULL
);

