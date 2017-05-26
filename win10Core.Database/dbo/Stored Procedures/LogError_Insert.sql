-- =============================================
-- Script Template
-- =============================================

  CREATE PROCEDURE LogError_Insert
(
	@LogErrorMethod		VARCHAR(50),
	@LogErrorMessage	VARCHAR(4000),
	@LogErrorSource		VARCHAR(4000)
)
AS
BEGIN

INSERT INTO [dbo].[LogError]
           ([LogErrorMethod]
           ,[LogErrorMessage]
           ,[LogErrorSource])
     VALUES
           (
		   @LogErrorMethod,
		   @LogErrorMessage,
		   @LogErrorSource
		   )

END