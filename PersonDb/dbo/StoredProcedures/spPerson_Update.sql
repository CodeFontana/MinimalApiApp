create procedure [dbo].[spPerson_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
as
begin
	update dbo.Person
	set FirstName = @FirstName,
		LastName = @LastName,
		[Updated] = GETUTCDATE(),
		[UpdatedBy] = SUSER_SNAME()
	where Id = @Id;
end