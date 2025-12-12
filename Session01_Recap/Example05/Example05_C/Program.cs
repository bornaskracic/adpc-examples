using Npgsql;

var cs = "Host=localhost;Username=postgres;Password=password;Database=postgres";

await using var con = new NpgsqlConnection(cs);
await con.OpenAsync();

await using var tx = await con.BeginTransactionAsync();

try
{
    int studentId = 10;

    // 1) Remove dependent exam applications
    const string delApps = @"DELETE FROM exam_application WHERE student_id = @id;";
    await using (var cmd = new NpgsqlCommand(delApps, con, tx))
    {
        cmd.Parameters.AddWithValue("id", studentId);
        await cmd.ExecuteNonQueryAsync();
    }

    // 2) Remove the student
    const string delStudent = @"DELETE FROM student WHERE id = @id;";
    await using (var cmd = new NpgsqlCommand(delStudent, con, tx))
    {
        cmd.Parameters.AddWithValue("id", studentId);
        await cmd.ExecuteNonQueryAsync();
    }

    await tx.CommitAsync();
    Console.WriteLine("Transaction committed successfully.");
}
catch (Exception ex)
{
    await tx.RollbackAsync();
    Console.WriteLine($"Transaction failed and rolled back: {ex.Message}");
}
