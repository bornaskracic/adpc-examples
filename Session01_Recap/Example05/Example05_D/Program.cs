using Example05_D.Repositories;

var students = await StudentRepository.GetStudentsAsync();

foreach (var s in students)
{
    Console.WriteLine($"{s.Id}: {s.FirstName} {s.LastName} ({s.EnrollmentYear})");
}
