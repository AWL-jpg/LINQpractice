<Query Kind="Expression">
  <Connection>
    <ID>86381896-2b80-4fe2-bf17-dc9c67230fb7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Sample for entity subset
//sample of entity navigation from child to parent on where
//reminder that code is C# and thus appropriate methods can be used .Equals to compare strings
from x in Customers
where x.SupportRepIdEmployee.FirstName.Equals("Jane") && x.SupportRepIdEmployee.LastName.Equals("Peacock")
select new{
	Name = x.LastName +","+ x.FirstName,
	City = x.City,
	State = x.State,
	Phone = x.Phone,
	Email = x.Email
}