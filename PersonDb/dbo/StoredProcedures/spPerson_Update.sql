CREATE PROCEDURE [dbo].[spPerson_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS
begin
	update dbo.Person
	set FirstName = @FirstName,
		LastName = @LastName,
		Modified = GETUTCDATE(),
		ModifiedBy = SUSER_SNAME()
	where Id = @Id;
end