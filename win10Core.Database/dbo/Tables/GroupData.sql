CREATE TABLE [dbo].[GroupData] (
    [GroupDataID]          INT            IDENTITY (1, 1) NOT NULL,
    [ClientID]             INT            NOT NULL,
    [GroupDataName]        VARCHAR (100)  NOT NULL,
    [GroupDataTitle]       VARCHAR (200)  NOT NULL,
    [GroupDataSubTitle]    VARCHAR (200)  NOT NULL,
    [GroupDataImage]       VARCHAR (50)   NOT NULL,
    [GroupDataDescription] VARCHAR (500)  NULL,
    [GroupDataContent]     VARCHAR (3000) NULL,
    CONSTRAINT [PK_GroupData] PRIMARY KEY CLUSTERED ([GroupDataID] ASC),
    CONSTRAINT [FK_GroupData_Client] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[Client] ([ClientID])
);

