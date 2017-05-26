CREATE TABLE [dbo].[XGlobal] (
    [GlobalID] INT         IDENTITY (1, 1) NOT NULL,
    [Year]     VARCHAR (4) NULL,
    CONSTRAINT [PK_XGlobal] PRIMARY KEY CLUSTERED ([GlobalID] ASC)
);

