using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example04.Data; 

[Table("group")]
public class Group
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
     [InverseProperty("Group")]
    public ICollection<Student> Students {get;set; }
}