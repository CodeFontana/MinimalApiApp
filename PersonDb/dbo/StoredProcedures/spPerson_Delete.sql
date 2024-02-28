create procedure [dbo].[spPerson_Delete]
	@Id int
as
begin
	delete from dbo.Person
	where Id = @Id;
end
