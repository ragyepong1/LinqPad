<Query Kind="Expression">
  <Connection>
    <ID>fceab41f-2719-48fd-9435-4e2381aeaff6</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

from data in Shifts
where data.PlacementContract.Location.Name.Contains("NAIT")
group data by data.DayOfWeek
into day
select new{
	DayOfWeek = (day.Key == 0 ? "Sun" :
					day.Key == 1 ? "Mon" :
					day.Key == 2 ? "Tue" :
					day.Key == 3 ? "Wed" :
					day.Key == 4 ? "Thu" :
					day.Key == 5 ? "Fri" :
					"Sat"),
	EmployeesNeeded = day.Sum(needed => needed.NumberOfEmployees)
}