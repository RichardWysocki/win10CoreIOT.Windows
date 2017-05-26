-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE ClientContributors_ListbyClientID
	-- Add the parameters for the stored procedure here
	@ClientID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT [ClientContributorsID]
      ,[ClientID]
      ,[SpecialContributors]
  FROM [dbo].[ClientContributors]
  WHERE
	ClientID = @ClientID	
END