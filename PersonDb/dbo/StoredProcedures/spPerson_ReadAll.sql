create procedure [dbo].[spPerson_ReadAll]
as
begin
	select Id, FirstName, LastName, Created, CreatedBy, [Updated], [UpdatedBy]
	from dbo.Person;
end
