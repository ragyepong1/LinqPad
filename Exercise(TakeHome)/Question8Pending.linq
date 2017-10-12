<Query Kind="Statements">
  <Connection>
    <ID>fceab41f-2719-48fd-9435-4e2381aeaff6</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

var wage = from data in Schedules
			select new {
			Shift = data.Shift,
			ShiftID = data.ShiftID,
			Employee = data.Employee,
			Wages = data.HourlyWage
			};
			
var hours = from data in wage
			where data.ShiftID == data.Shift.ShiftID
			select (data.Shift.EndTime - data.Shift.StartTime).TotalHours;

var regularEarnings = 	from data in wage
						from row in hours
						select wage.Wages * row;