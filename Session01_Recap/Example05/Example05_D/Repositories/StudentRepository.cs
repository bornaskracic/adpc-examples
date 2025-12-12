using Example05_D.Models;
using Npgsql;


namespace Example05_D.Repositories;

public static class StudentRepository
{
    private const string ConnectionString =
        "Host=localhost;Username=postgres;Password=password;Database=postgres";

    public static async Task<List<Student>> GetStudentsAsync()
    {
        var students = new List<Student>();

        await using var con = new NpgsqlConnection(ConnectionString);
        await con.OpenAsync();

        const string sql = @"SELECT id, first_name, last_name, enrollment_year FROM student";

        await using var cmd = new NpgsqlCommand(sql, con);
        await using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var student = new Student
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                EnrollmentYear = reader.GetInt32(3)
            };

            students.Add(student);
        }

        return students;
    }
}
