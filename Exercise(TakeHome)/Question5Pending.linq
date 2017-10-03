<Query Kind="Expression">
  <Connection>
    <ID>fceab41f-2719-48fd-9435-4e2381aeaff6</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

from row in Shifts
orderby row.DayOfWeek ascending
select new{
	DayOfWeek = (row.DayOfWeek == 0 ? "Sun" :
					row.DayOfWeek == 1 ? "Mon" :
					row.DayOfWeek == 2 ? "Tue" :
					row.DayOfWeek == 3 ? "Wed" :
					row.DayOfWeek == 4 ? "Thu" :
					row.DayOfWeek == 5 ? "Fri" :
					"Sat"),
	EmployeesNeeded = row.NumberOfEmployees
}