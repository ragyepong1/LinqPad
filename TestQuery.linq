<Query Kind="Expression">
  <Connection>
    <ID>8eabbc9c-bd34-4e94-a007-0e7a6ad81f3c</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

from data in EmployeeSkills
where data.Skill.Description.Contains("Plumber")
select new
{
	Name = data.Employee.FirstName + " " + data.Employee.LastName,
	ScheduledShifts = from shift in data.Employee.Schedules
		select new {
			Date = shift.Day,
			HourlyWage = shift.HourlyWage,
			Overtime = shift.OverTime
		}
}