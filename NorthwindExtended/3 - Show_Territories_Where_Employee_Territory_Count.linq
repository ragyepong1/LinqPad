<Query Kind="Expression">
  <Connection>
    <ID>81a75eb9-2d82-4fd3-900a-7cf2f154c463</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>NorthwindExtended</Database>
  </Connection>
</Query>

from person in Employees
where person.EmployeeTerritories.Count >= 2
select person.EmployeeTerritories//.Count