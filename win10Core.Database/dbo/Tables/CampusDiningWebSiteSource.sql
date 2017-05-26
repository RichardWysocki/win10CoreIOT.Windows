CREATE TABLE [dbo].[CampusDiningWebSiteSource] (
    [CampusDiningWebSiteSourceID]   INT          IDENTITY (1, 1) NOT NULL,
    [CampusDiningWebSiteSourceName] VARCHAR (50) NULL,
    CONSTRAINT [PK_CampusDiningWebSiteSource] PRIMARY KEY CLUSTERED ([CampusDiningWebSiteSourceID] ASC)
);

