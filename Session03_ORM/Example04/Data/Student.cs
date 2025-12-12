using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example04.Data;

[Table("student")]
public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id {get;set;}
    [Column("first_name")]
    public string FirstName {get;set;}
    [Column("last_name")]
    public string LastName {get;set;}
    [Column("group_id")]
    public int GroupId {get; set;}
    [ForeignKey("GroupId")]
    [InverseProperty("Students")]
    public Group Group {get;set;}
}