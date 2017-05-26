

CREATE PROCEDURE [dbo].[XmasPerson_Update]
	-- Add the parameters for the stored procedure here
	@XmasPersonID	int,
	@Person			VARCHAR(50),
	@XmasGroupID	int,
	@BudgetValue	money
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
Update
	XmasPerson
Set	
	Person			= 	@Person,
	XmasGroupID	= 	@XmasGroupID,
	BudgetValue	= 	@BudgetValue
WHERE
	XmasPersonID = @XmasPersonID
  
  
  
END