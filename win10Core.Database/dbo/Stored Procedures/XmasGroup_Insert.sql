

  CREATE PROCEDURE [dbo].[XmasGroup_Insert]
(
	@GroupName		VARCHAR(50)
)
AS
BEGIN

INSERT INTO dbo.XmasGroup
           (GroupName)
     VALUES
           (@GroupName)


END