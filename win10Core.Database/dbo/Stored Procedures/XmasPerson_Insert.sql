

Create PROCEDURE [dbo].[XmasPerson_Insert]
(
	@Person		VARCHAR(50),
	@XmasGroupID	INT,
	@BudgetValue	Money
)
AS
BEGIN

INSERT INTO dbo.XmasPerson
           (Person, XmasGroupID, BudgetValue)
     VALUES
           (@Person, @XmasGroupID, @BudgetValue)

END