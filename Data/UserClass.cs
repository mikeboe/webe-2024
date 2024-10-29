using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppCrud.Data
{
    [Table("users", Schema = "public")]
    public class UserClass
    {
        [Key] public string id { get; set; }

        public string userName { get; set; }

        public string email { get; set; }
    }
}