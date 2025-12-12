-- Example 05
-- In this example, you will work with raw databse connection from program code. The code will be written in C# and it will use Npgsql library.
-- This approach sets up the foundation for writing your own ORM (especially the query executor).

using Npgsql;

var cs = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=postgres";

await using var con = new NpgsqlConnection(cs);
await con.OpenAsync();

const string sql = @"
    INSERT INTO student (first_name, last_name, enrollment_year)
    VALUES (@first, @last, @year)
    RETURNING id;
";

await using var cmd = new NpgsqlCommand(sql, con);
cmd.Parameters.AddWithValue("first", "Lara");
cmd.Parameters.AddWithValue("last", "Knight");
cmd.Parameters.AddWithValue("year", 2024);

var newId = (int)await cmd.ExecuteScalarAsync();

Console.WriteLine($"Inserted new student with ID = {newId}");
