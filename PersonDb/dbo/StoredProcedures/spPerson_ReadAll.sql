create procedure [dbo].[spPerson_ReadAll]
as
begin
	select Id, FirstName, LastName, Created, CreatedBy, Modified, ModifiedBy
	from dbo.Person;
end
