<Query Kind="Statements">
  <Connection>
    <ID>fceab41f-2719-48fd-9435-4e2381aeaff6</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

//var Years = 	from data in EmployeeSkills
//				group data by data.EmployeeID
//				into employees
//				select new
//				{
//					SumOfYears = employees.Sum(x => x.YearsOfExperience)
//				};
//
//var maxYears = Years.Max(y => y.SumOfYears);
//
//var EmployeesWithMaxYears = from row in Employees
//							where row.EmployeeSkills.Sum(z => z.YearsOfExperience) == maxYears
//							select new
//							{
//								Employee = row.FirstName + " " + row.LastName,
//								YearsOfExperience = row.EmployeeSkills.Sum(z => z.YearsOfExperience)
//							};
//
//EmployeesWithMaxYears.Dump();
//
//

var EmployeeYOE = from x in Employees
				select new{
					Name = x.FirstName + " " + x.LastName,
					YOE = x.EmployeeSkills.Sum(row => row.YearsOfExperience)
				};

var q6 = from x in EmployeeYOE
		where x.YOE == EmployeeYOE.Max(row => row.YOE)
		select x;
		
q6.Dump("Q6");