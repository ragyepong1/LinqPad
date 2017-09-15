<Query Kind="Expression">
  <Connection>
    <ID>aa206032-2ab7-413b-b4cc-9dc9b497ff91</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>NorthwindExtended</Database>
  </Connection>
</Query>

// Give a list of all region names
// Give a list of all the territory names
// List all the regions and the number of territories in each region
// List all the region and territory names in a flat list
// List all the region and territory names as an "Object graph" - use a nested query
// Group employees by territory and show the results in this format

//from row in Regions
//select new
//{
//	Region = row.RegionDescription,
//	Territory = 	from item in row.Territories
//					select item.TerritoryDescription
//}

//from row in Regions
//select new
//{
//	Region = row.RegionDescription,
//	Employees = from territory in row.Territories
//				select new
//				{
//					Employees = from hires in territory.EmployeeTerritories
//								select new
//								{
//									Employee_Name = hires.Employee.LastName + ", " + hires.Employee.FirstName
//								}
//				}
//}

//OR

from data in EmployeeTerritories
group data by data.Territory.Region.RegionDescription into regionGroup
select new
{
	Region = regionGroup.Key,
	Employees = from person in regionGroup
				select person.Employee.LastName + ", " + person.Employee.FirstName
}