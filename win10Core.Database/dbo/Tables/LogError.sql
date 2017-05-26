CREATE TABLE [dbo].[LogError] (
    [LogErrorID]      INT            IDENTITY (1, 1) NOT NULL,
    [LogErrorMethod]  VARCHAR (50)   NULL,
    [LogErrorMessage] VARCHAR (4000) NULL,
    [LogErrorSource]  VARCHAR (4000) NULL,
    CONSTRAINT [PK_LogError] PRIMARY KEY CLUSTERED ([LogErrorID] ASC)
);

