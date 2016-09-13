<Query Kind="Statements">
  <Connection>
    <ID>6854e270-6550-409b-8626-36ea9385150a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//Waiters
var results = from x in Waiters
where x.FirstName.Contains("a")
orderby x.LastName
select x.LastName + "," + x.FirstName;
results.Dump();
