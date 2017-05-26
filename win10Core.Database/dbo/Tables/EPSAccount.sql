CREATE TABLE [dbo].[EPSAccount] (
    [EPSAccountID]             INT           IDENTITY (1, 1) NOT NULL,
    [ClientID]                 INT           NOT NULL,
    [EPSAccountDisplayName]    VARCHAR (100) NULL,
    [EPSAccountAccountName]    VARCHAR (100) NULL,
    [EPSAccountOrder]          INT           NULL,
    [EPSAccountActive]         BIT           NULL,
    [EPSAccountWebServicePath] VARCHAR (300) NULL,
    [EPSAccountKey1]           VARCHAR (50)  NULL,
    [EPSAccountKey2]           VARCHAR (50)  NULL,
    [EPSAccountTimeOut]        INT           NULL,
    [EPSAccountEncryptActive]  BIT           NULL,
    CONSTRAINT [EPSAccount_PK] PRIMARY KEY CLUSTERED ([EPSAccountID] ASC),
    CONSTRAINT [FK_EPSAccount_Client] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[Client] ([ClientID])
);

