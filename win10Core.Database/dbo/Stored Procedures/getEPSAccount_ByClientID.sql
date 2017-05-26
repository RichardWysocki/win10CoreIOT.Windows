-- =============================================
-- Script Template
-- =============================================
-- Stored Procedure

CREATE PROCEDURE [dbo].[getEPSAccount_ByClientID]
	-- Add the parameters for the stored procedure here
	@clientID varchar(5)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT
			[EPSAccountID]
		   ,[ClientID]
           ,[EPSAccountDisplayName]
           ,[EPSAccountAccountName]
           ,[EPSAccountOrder]
           ,[EPSAccountActive]
           ,[EPSAccountWebServicePath]
           ,[EPSAccountKey1]
           ,[EPSAccountKey2]
           ,[EPSAccountTimeOut]
           ,[EPSAccountEncryptActive]
	From 
		EPSAccount
	where
		ClientID = @clientID
END