<Query Kind="Expression">
  <Connection>
    <ID>84539d3b-94e0-4722-ad08-e5a782dcba5a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//Multiple column group
//grouping data in a local temp data set for further grouping 
//.key allows you to have access to the value(s) in your group key(s)
//if you have multiple group columns they must be in an anonymous datatype
//to create a DTO type collection you can use .ToList() on the temp data set 
// you can have a custom anonymus data collection by using a nested query


//Step A
from food in Items
	group food by new {food.MenuCategoryID, food.CurrentPrice}

//Step B: DTO DataSet
from food in Items
	group food by new {food.MenuCategoryID, food.CurrentPrice} into tempdataset
	select new{
				MenuCategoryID = tempdataset.Key.MenuCategoryID,
				CUrrentPrice = tempdataset.Key.CurrentPrice,
				FoodItems = tempdataset.ToList}


//Step C DTO Custom style Dataset
from food in Items
	group food by new {food.MenuCategoryID, food.CurrentPrice} into tempdataset
	select new{
				MenuCategoryID = tempdataset.Key.MenuCategoryID,
				CUrrentPrice = tempdataset.Key.CurrentPrice,
				FoodItems = from x in tempdataset
									select new{
												ItemID = x.ItemID,
												FoodDescription = x.Description,
												TimeServed = x.BillItems.Count()												
									}
	}