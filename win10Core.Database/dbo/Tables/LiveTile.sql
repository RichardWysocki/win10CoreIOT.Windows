CREATE TABLE [dbo].[LiveTile] (
    [LiveTileID]       INT           IDENTITY (1, 1) NOT NULL,
    [ClientID]         INT           NULL,
    [SortOrder]        INT           NULL,
    [TileType]         VARCHAR (50)  NULL,
    [TileWideText]     VARCHAR (100) NULL,
    [TileWideImageSRC] VARCHAR (100) NULL,
    [TileWideImageALT] VARCHAR (100) NULL,
    [TileSquareText]   VARCHAR (100) NULL
);

