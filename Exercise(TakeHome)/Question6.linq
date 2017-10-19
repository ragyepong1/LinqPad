<Query Kind="Statements">
  <Connection>
    <ID>bc76ba4d-9f6e-4d67-b0dc-411d43c86c92</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

var Years = 	from data in EmployeeSkills
				group data by data.EmployeeID
				into employees
				select new
				{
					SumOfYears = employees.Sum(x => x.YearsOfExperience)
				};

var maxYears = Years.Max(y => y.SumOfYears);

var EmployeesWithMaxYears = from row in Employees
							where row.EmployeeSkills.Sum(z => z.YearsOfExperience) == maxYears
							select new
							{
								Employee = row.FirstName + " " + row.LastName,
								YearsOfExperience = row.EmployeeSkills.Sum(z => z.YearsOfExperience)
							};

EmployeesWithMaxYears.Dump();
