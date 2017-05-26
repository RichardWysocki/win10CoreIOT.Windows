

Create PROCEDURE dbo.XmasGroup_Update
	-- Add the parameters for the stored procedure here
	@XmasGroupID	int,
	@GroupName		VARCHAR(50)
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
Update
	XmasGroup
Set	
	GroupName = 	@GroupName
WHERE
	XmasGroupID = @XmasGroupID
  
  
  
END