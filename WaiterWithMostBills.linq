<Query Kind="Statements">
  <Connection>
    <ID>6854e270-6550-409b-8626-36ea9385150a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

var WaiterWMostBills = from x in Waiters
					where x.Bills.Count() == (from y in Waiters 
												select y.Bills.Count()).Max()
					select new{
							Waiter = x.FirstName + " " + x.LastName,
							AmountOfBills = x.Bills.Count()
					};
						
WaiterWMostBills.Dump();

//create a dataset which contains the summary bill info by waiter
var WaiterBills = from x in Waiters 
					orderby x.LastName,
							x.FirstName
					select new {
					Name = x.LastName + "," + x.FirstName,
					BillInfo = (from y in Bills
								where y.BillItems.Count() > 0
								select new{
										BillID = y.BillID,
										BillDate = y.BillDate,
										TableID = y.TableID,
										Total = y.BillItems.Sum(b => b.SalePrice *b.Quantity)
										}
								)
							};
	WaiterBills.Dump();