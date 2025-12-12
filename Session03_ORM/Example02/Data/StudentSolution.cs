using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Example02.Data;

[Table("student_solution")]
public partial class StudentSolution
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("student_id")]
    public long StudentId { get; set; }

    [Column("schoolwork_id")]
    public long SchoolworkId { get; set; }

    [Column("solution")]
    public string? Solution { get; set; }

    [Column("submitted_at", TypeName = "timestamp without time zone")]
    public DateTime SubmittedAt { get; set; }

    [Column("points_graded")]
    public short? PointsGraded { get; set; }

    [ForeignKey("SchoolworkId")]
    [InverseProperty("StudentSolutions")]
    public virtual Schoolwork Schoolwork { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("StudentSolutions")]
    public virtual Student Student { get; set; } = null!;
}
