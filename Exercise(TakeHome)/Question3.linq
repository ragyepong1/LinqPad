<Query Kind="Expression">
  <Connection>
    <ID>fceab41f-2719-48fd-9435-4e2381aeaff6</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

//from data in EmployeeSkills
//orderby data.YearsOfExperience descending
//where data.Skill.RequiresTicket == false
//select new{
//	Description = data.Skill.Description,
//	Employees = from row in data
//				select new{
//					Name = row.Employee.FirstName + " " + row.Employee.LastName,
//					Level = (row.Level == 0 ? "Novice" : 
//								row.Level == 1 ? "Proficient" : "Expert"),
//					YearsExperience = row.YearsOfExperience
//				}
//}

from data in Skills
where data.RequiresTicket == true
select new{
	Description = data.Description,
	Employees = from row in data.EmployeeSkills
				orderby row.YearsOfExperience descending
				select new{
					Name = row.Employee.FirstName + " " + row.Employee.LastName,
					Level = (row.Level == 1 ? "Novice" : 
								row.Level == 2 ? "Proficient" : "Expert"),
					YearsExperience = row.YearsOfExperience
				}
}