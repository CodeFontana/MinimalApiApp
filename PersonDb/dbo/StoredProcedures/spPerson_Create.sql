CREATE PROCEDURE [dbo].[spPerson_Create]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Id int OUTPUT
AS
begin
	insert into dbo.Person (FirstName, LastName)
	values (@FirstName, @LastName);

	set @Id = SCOPE_IDENTITY();
end
