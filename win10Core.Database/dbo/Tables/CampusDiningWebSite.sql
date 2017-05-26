CREATE TABLE [dbo].[CampusDiningWebSite] (
    [CampusDiningWebSiteID]       INT           IDENTITY (1, 1) NOT NULL,
    [CampusDiningWebSiteName]     VARCHAR (100) NULL,
    [CampusDiningWebSiteAddress]  VARCHAR (150) NULL,
    [CampusDiningWebSiteSourceID] INT           NULL,
    CONSTRAINT [PK_CampusDiningWebSite] PRIMARY KEY CLUSTERED ([CampusDiningWebSiteID] ASC),
    CONSTRAINT [FK_CampusDiningWebSite_CampusDiningWebSiteSource] FOREIGN KEY ([CampusDiningWebSiteSourceID]) REFERENCES [dbo].[CampusDiningWebSiteSource] ([CampusDiningWebSiteSourceID])
);

