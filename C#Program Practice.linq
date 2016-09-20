<Query Kind="Program">
  <Connection>
    <ID>6854e270-6550-409b-8626-36ea9385150a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

void Main()
{
	//a list of billcounts for all waiters
	//this query will create a flat dataset
	//the columns are native dataTypes
	// One is not Concerned with repeated data in a column
	//Instead of using an anonymous datatype (new{.......})
	var WaiterWMostBills = from x in Waiters
					select new WaiterBillCounts {
							Waiter = x.FirstName + " " + x.LastName,
							AmountOfBills = x.Bills.Count()
					};
						
	WaiterWMostBills.Dump();
	
	var WaiterBills = from x in Waiters
					where x.LastName.Contains("a")
					orderby x.LastName,
							x.FirstName
					select new WaiterBills {
						Name = x.LastName + "," + x.FirstName,
						TotalBillCount = x.Bills.Count(),
						BillInfo = (from y in Bills
								where y.BillItems.Count() > 0
								select new BillItemSummary{
										BillID = y.BillID,
										BillDate = y.BillDate,
										TableID = y.TableID,
										Total = y.BillItems.Sum(b => b.SalePrice *b.Quantity)
										}
								).ToList() //Converts it from ENumerable to a list
							};
	WaiterBills.Dump();
}

// Define other methods and classes here
//An example of a poco class
public class WaiterBillCounts
{
	//whatever recieving field on your query in your select
	//appears as a property in this class
	public string Waiter{get;set;}
	public int AmountOfBills{get;set;}
}
public class BillItemSummary
{
	public int BillID{get;set;}
	public DateTime BillDate{get;set;}
	public int? TableID{get;set;} //"?" means it can be nullable
	public decimal Total{get;set;}
}
 public class WaiterBills{
 	public string Name{get;set;}
	public int TotalBillCount{get;set;}
	public List<BillItemSummary> BillInfo{get;set;}
 }




















