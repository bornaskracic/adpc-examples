The following examples contain examples on how to use ORM - Entity Framework, following the topics that have been covered on the lectures.

#### Example 01
First example shows how to use basic functionality of the ORM, which is accessing the data through program code (in this examples - C#). \
First, start with preparing the Postgres instance (makes sure that Docker is installed on your system):
```bash
docker run --name postgres-local -e POSTGRES_PASSWORD=password -p 5432:5432 -d postgres:18
```
Then, execute the attached setup script - `student_manager_seed.sql`. You can do this in many different ways but the easiest one is to copy fhe file into the running container and then run the script using `docker exec`:
```bash
docker cp student_manager_seed.sql postgres-local:/seed.sql
docker exec postgres-local psql -U postgres -f seed.sql
```
There is no need to set `-it` flag since `psql` is not used in the REPL mode but instead used to execute one script. However, the `-U <username>` flag is still required since Postgres user is named `postgres` and psql connection is established with local user by default (which would be `root`).


Then create new .NET console project (you can use `dotnet new console --name <project name>`) and perform `scaffolding` which is the process of generating class definitions based on the database schema - **database first** approach. First, the following packages need to be installed:

```
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Npgsql.EntityFrameworkCore.PostgreSQL
```

Then you can scaffold the database (make sure that `dotnet-ef` tool is installed):
```bash
dotnet ef dbcontext scaffold "Host=localhost;Port=5432;Username=postgres;Password=password;Database=postgres;" Npgsql.EntityFrameworkCore.PostgreSQL -o Data --data-annotations
```

The code in the `Program.cs` shows how to use the basic functionalites of Entity Framework ORM.

#### Example 02
This example shows how change tracker works when handling changes on the tracked objects. (For the sake of convenience, you can scaffold the previously configured database instance)

#### Example 03
This example shows how to work with related data by utilizing different approaches (lazy and eager loading). Related data is usually accessed through navigational properties:
```c#
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Example01.Data;

[Table("student")]
public partial class Student
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("first_name")]
    [StringLength(255)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(255)]
    public string LastName { get; set; } = null!;

    [Column("jmbag")]
    [StringLength(13)]
    public string Jmbag { get; set; } = null!;

    [Column("group_id")]
    public long GroupId { get; set; }

    [ForeignKey("GroupId")]
    [InverseProperty("Students")]
    public virtual StudentGroup Group { get; set; } = null!;

    [InverseProperty("Student")]
    public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentSolution> StudentSolutions { get; set; } = new List<StudentSolution>();
}
```
In this example ` [Column("group_id")] virtual StudentGroup Group` associates given student with exacly up to one group (since it is nullable). When retrieving data about the group in which the student belongs to, `Group` property getter will be used; this statement will be translated to the adequate separate query if using **lazy loading** approach. However, if **eager loading** approach is used instead, the data about the student's group will be retrieved when retrieving data about the student itself (using `JOIN` in mapped SQL statements). 

#### Example 04
This example displays how to utilize the **code first** approach which starts by defining classes for the required entities. Afterwards, the initial migration is created and executed against the target database (to make things easier you can remove the previously set container with `docker rm -f postgres-local` and recreate it from scratch as previously described).

Make sure to first install the required `EntityFramework` packages. Then create the appropriate `DbContext` subclass that lists all of the entities in its `DbSet<T>` properties. Afterwards, create the initiak migration:
```bash
dotnet ef migrations add InitialMigration
```
Finally, update the database according to the created migraiton:
```bash
dotnet ef database update
```
Remember, you can also roll-back or fast-forward to the desired migration (or in another words: database schema) by specifiying the migration identifier:
```bash
dotent ef database update <migration identifier>
```