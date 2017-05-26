CREATE PROCEDURE [dbo].[getRecipeItem]
	-- Add the parameters for the stored procedure here
	@RecipeNutritionalID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		RecipeNutritionalID,
		RecipeName,
		RecipeItemServingDescription,
		RecipeItemDescription,
		RecipeItemCalories,
		RecipeItemTotalFat,
		RecipeItemCholesterol,
		RecipeItemSodium,
		RecipeItemPotassium,
		RecipeItemTotalCarbohydrate,
		RecipeItemProtein,
		RecipeItemID
	
	From 
		RecipeNutritional
	where
		RecipeNutritionalID = @RecipeNutritionalID
END