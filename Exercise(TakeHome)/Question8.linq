<Query Kind="Expression">
  <Connection>
    <ID>fceab41f-2719-48fd-9435-4e2381aeaff6</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

from x in Schedules.ToList()
where x.Day.Month == 11
group x by x.Employee into groupEmployee 
select new{
	Name = groupEmployee.Key.FirstName + " " + groupEmployee.Key.LastName,
	RegularEarnings = groupEmployee.Where(row => !row.OverTime)
						.Sum(row => row.HourlyWage * 1.5m * (row.Shift.EndTime-row.Shift.StartTime).Hours).ToString("0.00"),
   	OvertimeEarnings = groupEmployee.Where(row => row.OverTime)
						.Sum(row => row.HourlyWage * 1.5m * (row.Shift.EndTime-row.Shift.StartTime).Hours).ToString("0.00"),
	NumberOfShifts = groupEmployee.Count(),
}