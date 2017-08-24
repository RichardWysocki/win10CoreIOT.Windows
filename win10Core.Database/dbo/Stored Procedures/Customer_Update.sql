


Create PROCEDURE [dbo].[Customer_Update]
	-- Add the parameters for the stored procedure here
	@CustomerId	int,
	@FirstName	VARCHAR(50),
	@LastName	Varchar(50)
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
AS
BEGIN
    -- Update statements for procedure here
UPDATE 
	[dbo].[Customer]
SET
	FirstName = @FirstName,
	LastName = @LastName
WHERE
	CustomerID = @CustomerId
  
  
  
END