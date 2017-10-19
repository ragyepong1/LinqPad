<Query Kind="Expression">
  <Connection>
    <ID>bc76ba4d-9f6e-4d67-b0dc-411d43c86c92</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

from data in Shifts
where data.PlacementContract.PlacementContractID == 3
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