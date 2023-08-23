CREATE PROCEDURE [dbo].[spPerson_ReadAll]
AS
begin
	select Id, FirstName, LastName, Created, CreatedBy, Modified, ModifiedBy
	from dbo.Person;
end
