CREATE TABLE [dbo].[MenuGroup] (
    [MenuGroupID]          INT           IDENTITY (1, 1) NOT NULL,
    [MenuGroupName]        VARCHAR (50)  NULL,
    [MenuGroupDescription] VARCHAR (100) NULL,
    [LocationID]           INT           NULL,
    CONSTRAINT [PK_MenuGroup] PRIMARY KEY CLUSTERED ([MenuGroupID] ASC)
);

