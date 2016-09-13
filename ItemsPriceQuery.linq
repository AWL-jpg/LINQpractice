<Query Kind="Statements">
  <Connection>
    <ID>6854e270-6550-409b-8626-36ea9385150a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from x in Items
where x.CurrentPrice > 5.00m
orderby x.CurrentPrice
select new{
		x.Description
		x.Calories
}