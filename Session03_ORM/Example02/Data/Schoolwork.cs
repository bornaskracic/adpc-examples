using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Example02.Data;

[Table("schoolwork")]
public partial class Schoolwork
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("task_text")]
    [StringLength(255)]
    public string TaskText { get; set; } = null!;

    [Column("learning_outcome")]
    public short LearningOutcome { get; set; }

    [Column("max_points")]
    public short MaxPoints { get; set; }

    [InverseProperty("Schoolwork")]
    public virtual ICollection<StudentSolution> StudentSolutions { get; set; } = new List<StudentSolution>();
}
