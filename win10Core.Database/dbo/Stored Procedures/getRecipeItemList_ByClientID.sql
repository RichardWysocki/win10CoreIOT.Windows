CREATE PROCEDURE [dbo].[getRecipeItemList_ByClientID]
	-- Add the parameters for the stored procedure here
	@clientID varchar(5)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		RecipeItemID,
		RecipeItemName,
		RecipeItemNameDescription,
		MenuGroupID
	From Recipe
	where
		MenuGroupID IN (SELECT MenuGroupID from MenuGroup where LocationID in (Select LocationID from Location where ClientID = @clientID))
END