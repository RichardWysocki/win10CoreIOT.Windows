
CREATE PROCEDURE [dbo].[Kid_Delete]
	-- Add the parameters for the stored procedure here
	@KidID int
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
DELETE
FROM 
	[dbo].[XKid]
WHERE
	KidID = @KidID
  
  
  
END