
CREATE PROCEDURE [dbo].[Customer_Delete]
	-- Add the parameters for the stored procedure here
	@CustomerId int
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- SET NOCOUNT ON;

    -- Delete statements for procedure here
DELETE
FROM 
	[dbo].Customer
WHERE
	CustomerID = @CustomerId
  
  
  
END