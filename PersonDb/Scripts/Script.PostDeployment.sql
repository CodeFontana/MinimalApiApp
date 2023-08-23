if not exists (select 1 from dbo.Person)
begin
	insert into dbo.Person (FirstName, LastName)
	values ('Jerry', 'Seinfeld');
	insert into dbo.Person (FirstName, LastName)
	values ('George', 'Costanza');
	insert into dbo.Person (FirstName, LastName)
	values ('Elaine', 'Benes');
	insert into dbo.Person (FirstName, LastName)
	values ('Cosmo', 'Kramer');
	insert into dbo.Person (FirstName, LastName)
	values ('Norman', 'Newman');
end