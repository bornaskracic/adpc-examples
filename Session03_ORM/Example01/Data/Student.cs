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
