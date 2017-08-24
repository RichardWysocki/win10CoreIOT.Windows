CREATE TABLE [dbo].[LogInfo] (
    [LogInfoID] INT            IDENTITY (1, 1) NOT NULL,
    [Method]    VARCHAR (100)  NULL,
    [Message]   VARCHAR (4000) NULL,
    CONSTRAINT [PK_LogInfo] PRIMARY KEY CLUSTERED ([LogInfoID] ASC)
);

