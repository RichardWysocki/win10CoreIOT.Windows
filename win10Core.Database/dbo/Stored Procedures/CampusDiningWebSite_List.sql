-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE CampusDiningWebSite_List
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [CampusDiningWebSiteID]
      ,[CampusDiningWebSiteName]
      ,[CampusDiningWebSiteAddress]
      ,CampusDiningWebSiteSource.[CampusDiningWebSiteSourceID]
	  ,CampusDiningWebSiteSourceName
  FROM [CampusDiningWebSite] 
	inner Join CampusDiningWebSiteSource
	on CampusDiningWebSite.CampusDiningWebSiteSourceID = CampusDiningWebSiteSource.CampusDiningWebSiteSourceID
	
		
END