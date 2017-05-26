CREATE TABLE [dbo].[XmasPresentList] (
    [XmasPresentListID] INT           IDENTITY (1, 1) NOT NULL,
    [Year]              INT           NULL,
    [XmasPersonID]      INT           NULL,
    [GiftsDescription]  VARCHAR (300) NULL,
    [IsDone]            BIT           NULL,
    CONSTRAINT [PK_XmasPresentList] PRIMARY KEY CLUSTERED ([XmasPresentListID] ASC),
    CONSTRAINT [FK_XmasPresentList_XmasPerson] FOREIGN KEY ([XmasPersonID]) REFERENCES [dbo].[XmasPerson] ([XmasPersonID])
);

