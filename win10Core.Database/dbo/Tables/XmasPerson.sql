CREATE TABLE [dbo].[XmasPerson] (
    [XmasPersonID] INT          IDENTITY (1, 1) NOT NULL,
    [Person]       VARCHAR (50) NULL,
    [XmasGroupID]  INT          NULL,
    [BudgetValue]  MONEY        NULL,
    CONSTRAINT [PK_XmasPerson] PRIMARY KEY CLUSTERED ([XmasPersonID] ASC),
    CONSTRAINT [FK_XmasPerson_XmasGroup] FOREIGN KEY ([XmasGroupID]) REFERENCES [dbo].[XmasGroup] ([XmasGroupID])
);

