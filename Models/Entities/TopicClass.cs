using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlazorAppCrud.Models.Entities;

[Table("topics", Schema = "public")]
public class TopicClass
{
    [Key]
    [Column("id")]
    public string Id { get; set; }
    
    [Column("title")]
    public string Title { get; set; }
    
    [Column("description")]
    public string Description { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

}