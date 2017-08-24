
-- =============================================
-- Script Template
-- =============================================

  Create PROCEDURE [dbo].Customer_Insert
(
	@FirstName			VARCHAR(50),
	@LastName			VARCHAR(150)
)
AS
BEGIN

INSERT INTO [dbo].Customer
           (FirstName
           ,LastName)
     VALUES
           (@FirstName
           ,@LastName)


END