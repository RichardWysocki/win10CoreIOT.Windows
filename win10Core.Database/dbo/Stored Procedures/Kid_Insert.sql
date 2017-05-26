
-- =============================================
-- Script Template
-- =============================================

  CREATE PROCEDURE [dbo].[Kid_Insert]
(
	@Name			VARCHAR(50),
	@Email			VARCHAR(150)
)
AS
BEGIN

INSERT INTO [dbo].[XKid]
           (Name
           ,Email)
     VALUES
           (@Name
           ,@Email)


END