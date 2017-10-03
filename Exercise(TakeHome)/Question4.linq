<Query Kind="Expression">
  <Connection>
    <ID>fceab41f-2719-48fd-9435-4e2381aeaff6</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

from data in Employees
where data.EmployeeSkills.Count > 1
select new{
	Name = data.FirstName + " " + data.LastName,
	Skills = from row in data.EmployeeSkills
				select new{
					Description = row.Skill.Description,
					Level = (row.Level == 1 ? "Novice" : 
								row.Level == 2 ? "Proficient" : "Expert"),
					YearsExperience = row.YearsOfExperience
				}
}