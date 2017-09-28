CREATE TABLE [dbo].[Gift] (
    [GiftID]     INT           IDENTITY (1, 1) NOT NULL,
    [KidID]      INT           NULL,
    [GiftName]   VARCHAR (200) NULL,
    [Priority]   INT           NULL,
    [WebUrl]     VARCHAR (200) NULL,
    [CreateDate] DATETIME      CONSTRAINT [DF_Gift_CreateDate] DEFAULT (getdate()) NULL,
    [EmailSent]  BIT           CONSTRAINT [DF_Gift_EmailSent] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_Gift] PRIMARY KEY CLUSTERED ([GiftID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20170915-145813]
    ON [dbo].[Gift]([EmailSent] ASC);

