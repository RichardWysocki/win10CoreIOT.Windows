CREATE TABLE [dbo].[ContactUs] (
    [ContactUsID] INT            IDENTITY (1, 1) NOT NULL,
    [ClientID]    INT            NOT NULL,
    [FirstName]   VARCHAR (50)   NULL,
    [LastName]    VARCHAR (50)   NULL,
    [Email]       VARCHAR (100)  NULL,
    [Subject]     VARCHAR (100)  NULL,
    [Comments]    VARCHAR (2000) NULL,
    CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED ([ContactUsID] ASC),
    CONSTRAINT [FK_ContactUs_Client1] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[Client] ([ClientID])
);

