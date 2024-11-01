using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppCrud.Models.Entities
{
    [Table("users", Schema = "public")]
    public class UserClass
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Column("userName")]
        public string UserName { get; set; }

        [Column("email")]
        public string Email { get; set; }
        
        [Column("password")]
        public string Password { get; set; }
        
        [Column("role")]
        public string Role { get; set; }
    }
}