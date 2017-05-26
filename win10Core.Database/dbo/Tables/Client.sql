CREATE TABLE [dbo].[Client] (
    [ClientID]   INT           IDENTITY (1, 1) NOT NULL,
    [ClientName] VARCHAR (100) NULL,
    [Latitude]   FLOAT (53)    NULL,
    [Longitude]  FLOAT (53)    NULL,
    [WebSiteURL] VARCHAR (200) NULL,
    [Active]     BIT           NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([ClientID] ASC)
);

