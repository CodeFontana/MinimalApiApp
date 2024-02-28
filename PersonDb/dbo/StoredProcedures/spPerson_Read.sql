create procedure [dbo].[spPerson_Read]
	@Id int
as
begin
	select Id, FirstName, LastName, Created, CreatedBy, Modified, ModifiedBy
	from dbo.Person 
	where Id = @Id;
end
