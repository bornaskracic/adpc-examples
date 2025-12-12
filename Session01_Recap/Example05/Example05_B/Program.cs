using Npgsql;

var cs = "Host=localhost;Username=postgres;Password=password;Database=postgres";

await using var con = new NpgsqlConnection(cs);
await con.OpenAsync();

const string sql = @"
    UPDATE exam_application
    SET points_scored = @pts,
        status = @status
    WHERE id = @id;
";

await using var cmd = new NpgsqlCommand(sql, con);
cmd.Parameters.AddWithValue("pts", 88.75m);
cmd.Parameters.AddWithValue("status", "passed");
cmd.Parameters.AddWithValue("id", 42);

var rows = await cmd.ExecuteNonQueryAsync();
Console.WriteLine($"Updated {rows} row(s).");
