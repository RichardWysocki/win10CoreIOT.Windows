-- =============================================
-- Script Template
-- =============================================

  CREATE PROCEDURE [dbo].[FeedBack_Insert]
(
    @ClientID		INT,
	@FirstName		VARCHAR(100),
	@LastName		VARCHAR(100),
	@Email			VARCHAR(100) = '',
	@Subject		VARCHAR(100),
	@Comments		VARCHAR(2000)
)
AS
BEGIN

INSERT INTO [dbo].[Feedback]
           ([ClientID]
           ,[FirstName]
           ,[LastName]
           ,[Email]
           ,[Subject]
           ,[Comments])
     VALUES
           (@ClientID
           ,@FirstName
           ,@LastName
           ,@Email
           ,@Subject
           ,@Comments)


END