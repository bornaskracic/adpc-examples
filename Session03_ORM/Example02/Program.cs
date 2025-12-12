using Example02.Data;

PostgresContext context = new();

var student = context.Students.First(s => s.Id == 1); 
                            // SELECT * FROM student WHERE id = 1;

foreach (var entry in context.ChangeTracker.Entries())
{
    // We can inspect the current values and new values assigned to the tracked values.
    Console.WriteLine($"{entry.Entity.GetHashCode()} {entry.Entity.GetType()} - {entry.State}");
}

student.LastName = "NEW VALUE";

// Now inspect the objects in the change tracker and notice the difference in object state.
foreach (var entry in context.ChangeTracker.Entries())
{
    // We can inspect the current values and new values assigned to the tracked values.
    // -> entry.CurrentValues - property that stores new values for a given object
    // -> entry.OriginalValues - property that stores old values for a given object
    Console.WriteLine($"{entry.Entity.GetHashCode()} {entry.Entity.GetType()} - {entry.State}");
}

// Commit the changes
context.SaveChanges();

// Finally, inspect the state of the tracked object after the transaction has been committed
foreach (var entry in context.ChangeTracker.Entries())
{
    Console.WriteLine($"{entry.Entity.GetHashCode()} {entry.Entity.GetType()} - {entry.State}");
}