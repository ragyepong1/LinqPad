<Query Kind="Expression">
  <Connection>
    <ID>fceab41f-2719-48fd-9435-4e2381aeaff6</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

//from data in Employees
//where data.Schedules.Count(x => x.Day.Month == 11) == 0
//orderby data.LastName, data.FirstName
//select data.LastName + ", " + data.FirstName

from x in Employees
orderby x.LastName, x.FirstName
where !x.Schedules.Any(row => row.Day.Month == 11)
select x.LastName + ", " + x.FirstName