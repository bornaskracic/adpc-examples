using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Example01.Data;

[Table("student_group")]
public partial class StudentGroup
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [StringLength(10)]
    public string Name { get; set; } = null!;

    [Column("academic_year")]
    public short AcademicYear { get; set; }

    [InverseProperty("Group")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
