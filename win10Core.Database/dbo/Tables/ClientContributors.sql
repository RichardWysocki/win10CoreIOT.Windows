CREATE TABLE [dbo].[ClientContributors] (
    [ClientContributorsID] INT            IDENTITY (1, 1) NOT NULL,
    [ClientID]             INT            NULL,
    [SpecialContributors]  VARCHAR (1000) NULL,
    CONSTRAINT [PK_ClientContributors] PRIMARY KEY CLUSTERED ([ClientContributorsID] ASC),
    CONSTRAINT [FK_ClientContributors_Client] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[Client] ([ClientID])
);

