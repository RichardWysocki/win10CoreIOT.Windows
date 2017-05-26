CREATE TABLE [dbo].[Feedback] (
    [FeedbackID] INT            IDENTITY (1, 1) NOT NULL,
    [ClientID]   INT            NOT NULL,
    [FirstName]  VARCHAR (50)   NOT NULL,
    [Lastname]   VARCHAR (50)   NULL,
    [Email]      VARCHAR (100)  NULL,
    [Subject]    VARCHAR (100)  NULL,
    [Comments]   VARCHAR (2000) NULL,
    CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED ([FeedbackID] ASC)
);

