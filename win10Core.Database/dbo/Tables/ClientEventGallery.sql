CREATE TABLE [dbo].[ClientEventGallery] (
    [ClientEventGalleryID]        INT           IDENTITY (1, 1) NOT NULL,
    [ClientID]                    INT           NOT NULL,
    [ClientEventGalleryName]      VARCHAR (50)  NULL,
    [ClientEventGalleryPath]      VARCHAR (100) NULL,
    [ClientEventGalleryEndDate]   DATE          NULL,
    [ClientEventGallerySortOrder] INT           NULL,
    [ClientEventGalleryActive]    BIT           NULL,
    CONSTRAINT [PK_ClientEventGallery] PRIMARY KEY CLUSTERED ([ClientEventGalleryID] ASC),
    CONSTRAINT [FK_ClientEventGallery_ClientEventGallery] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[Client] ([ClientID])
);

