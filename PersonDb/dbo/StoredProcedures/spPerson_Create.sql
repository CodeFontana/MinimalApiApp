create procedure [dbo].[spPerson_Create]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Id int OUTPUT
as
begin
	insert into dbo.Person (FirstName, LastName)
	values (@FirstName, @LastName);

	set @Id = SCOPE_IDENTITY();
end
