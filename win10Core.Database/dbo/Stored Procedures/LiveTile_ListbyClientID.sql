Create PROCEDURE [dbo].LiveTile_ListbyClientID
	-- Add the parameters for the stored procedure here
	@ClientID int
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT [LiveTileID]
      ,[ClientID]
      ,[SortOrder]
	  ,[TileType]
      ,[TileWideText]
      ,[TileWideImageSRC]
      ,[TileWideImageALT]
      ,[TileSquareText]
FROM 
	[LiveTile]
WHERE
	ClientID = @ClientID
  
  
  
  
END