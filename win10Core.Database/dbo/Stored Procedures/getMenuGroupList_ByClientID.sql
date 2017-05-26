CREATE PROCEDURE [dbo].[getMenuGroupList_ByClientID]
	-- Add the parameters for the stored procedure here
	@clientID varchar(5)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		MenuGroupID,
		MenuGroupName,
		MenuGroupDescription,
		LocationID
	From MenuGroup
	where
		LocationID in (Select LocationID from Location where ClientID = @clientID)
END