<Query Kind="Expression">
  <Connection>
    <ID>81a75eb9-2d82-4fd3-900a-7cf2f154c463</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>NorthwindExtended</Database>
  </Connection>
</Query>

from person in Customers
where person.Orders.Count > 5
select new
{
	ID = person.CustomerID,
	Name = person.ContactName
}