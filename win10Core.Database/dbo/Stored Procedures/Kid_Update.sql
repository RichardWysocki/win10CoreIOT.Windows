


CREATE PROCEDURE [dbo].[Kid_Update]
	-- Add the parameters for the stored procedure here
	@KidID	int,
	@Name	VARCHAR(50),
	@Email	Varchar(150)
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
AS
BEGIN
    -- Update statements for procedure here
Update
	XKid
Set	
	Name	= 	@Name,
	Email	= 	@Email
WHERE
	KidID = @KidID
  
  
  
END