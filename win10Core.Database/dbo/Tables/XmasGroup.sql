CREATE TABLE [dbo].[XmasGroup] (
    [XmasGroupID] INT          IDENTITY (1, 1) NOT NULL,
    [GroupName]   VARCHAR (50) NULL,
    CONSTRAINT [PK_XmasGroup] PRIMARY KEY CLUSTERED ([XmasGroupID] ASC)
);

