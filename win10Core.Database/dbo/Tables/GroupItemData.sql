CREATE TABLE [dbo].[GroupItemData] (
    [GroupItemDataID]          INT            IDENTITY (1, 1) NOT NULL,
    [GroupItemDataName]        VARCHAR (100)  NOT NULL,
    [GroupItemDataTitle]       VARCHAR (200)  NOT NULL,
    [GroupItemDataSubTitle]    VARCHAR (200)  NOT NULL,
    [GroupItemDataImage]       VARCHAR (50)   NOT NULL,
    [GroupItemDataDescription] VARCHAR (500)  NOT NULL,
    [GroupItemDataContent]     VARCHAR (6000) NULL,
    [GroupDataID]              INT            NOT NULL,
    CONSTRAINT [PK_GroupItemData] PRIMARY KEY CLUSTERED ([GroupItemDataID] ASC),
    CONSTRAINT [FK_GroupItemData_GroupData] FOREIGN KEY ([GroupDataID]) REFERENCES [dbo].[GroupData] ([GroupDataID])
);

