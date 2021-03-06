<Query Kind="Statements">
  <Connection>
    <ID>15f27851-d6c8-4ad3-8dc1-b20f2f7dad91</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//use of aggragates(one of which is .Count()) in queries
//.Count() counts the number of instances of the collection reference
//.Sum() totals a specific field, thus you will likely need to use a delagate( y.___) to  indicate the collection instance attribute to be used 
//.Average() averages a specific  field/expression, thus you will likeley need to use a delegate( y.___) to indicate the collection instance attribute to be used
from x in Albums
orderby x.Title
where x.Tracks.Count() > 0 // added this because there were albums that had no tracks
select new{
	Title = x.Title,
	NumberOfTracks =  x.Tracks.Count(),
	TotalTrackPrice = x.Tracks.Sum(y => y.UnitPrice),
	AverageTrackLengthInSecondsA = (x.Tracks.Average(y => y.Milliseconds))/1000, //overall average then devides the average by a thousand
	AverageTrackLengthInSecondsB = x.Tracks.Average(y => y.Milliseconds/1000)// equation is now inside the delagate making the average less precise 
}
// MEDIA TYPE WITH THE MOST TRACKS FOR MONDAY