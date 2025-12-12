using Npgsql;

var cs = "Host=localhost;Username=postgres;Password=password;Database=postgres";

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
