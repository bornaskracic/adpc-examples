using Example04.Data;
using Microsoft.EntityFrameworkCore;

StudentManagerContext context = new();

var students = context
                    .Students
                    .Include(s => s.Group); 

// select * from student left join group on group.id = student.group_id

foreach (var student in students)
{
    System.Console.WriteLine($"{student.FirstName} {student.LastName} => {student.Group.Name}");
}