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
	
	// can this set of statements be done as one complete  query
	// the answer is possibly and in this case yes
	// in this example maxCount could be  exchanged for the query that 
	// actually created the value in the first place 
var popularMediaTypeSubQuery = from x in MediaTypes
						where x.Tracks.Count() == (from y in MediaTypes 
													select y.Tracks.Count()).Max()
						select new{
								Type = x.Name,
								TypeCount = x.Tracks.Count()
						};
						
	popularMediaTypeSubQuery.Dump();


//using the method syntax to determine the count value for the wehre
//expression this demonstrates that querys can be constructed
var popularMediaTypeSubMethod = from x in MediaTypes
						where x.Tracks.Count() == 
										MediaTypes.Select (my => mt.Tracks.Count()).Max
						select new{
								Type = x.Name,
								TypeCount = x.Tracks.Count()
						};
						
	popularMediaTypeSubMethod.Dump();
