CREATE PROCEDURE [dbo].[spPerson_Read]
	@Id int
AS
begin
	select Id, FirstName, LastName, Created, CreatedBy, Modified, ModifiedBy
	from dbo.Person 
	where Id = @Id;
end
