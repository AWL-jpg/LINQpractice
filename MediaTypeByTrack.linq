<Query Kind="Statements">
  <Connection>
    <ID>15f27851-d6c8-4ad3-8dc1-b20f2f7dad91</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// when you have to use multiple steps to solve a problem, change your language typ to Statements or Program
// the results of each query will now be solved in a variable

/*from x in MediaTypes 
orderby x.Tracks.Count()
select new{
	Name =x.Name,
	NumberOfTracks = x.Tracks.Count()
}*/
var maxCount = (from x in MediaTypes 
	select x.Tracks.Count()).Max();
	
// to display the contents of a variable in linqpad you use the method .Dump()
 maxCount.Dump();
 
var popularMediaType = from x in MediaTypes
						where x.Tracks.Count() == maxCount
						select new{
								Type = x.Name,
								TypeCount = x.Tracks.Count()
						};
						
	popularMediaType.Dump();