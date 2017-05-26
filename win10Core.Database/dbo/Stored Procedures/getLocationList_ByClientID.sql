CREATE PROCEDURE [dbo].[getLocationList_ByClientID]
	-- Add the parameters for the stored procedure here
	@clientID varchar(5)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT
		LocationID,
		LocationName,
		LocationDescription,
		Latitude,
		Longitude,
		WebAddress,
		ClientID
	From 
		Location
	where
		ClientID = @clientID
END