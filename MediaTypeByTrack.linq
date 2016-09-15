<Query Kind="Expression">
  <Connection>
    <ID>86381896-2b80-4fe2-bf17-dc9c67230fb7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

from x in MediaTypes 
orderby x.Tracks.Count()
select new{
	Name =x.Name,
	NumberOfTracks = x.Tracks.Count()
}