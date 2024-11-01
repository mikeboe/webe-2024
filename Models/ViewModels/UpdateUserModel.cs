using System.ComponentModel.DataAnnotations;

namespace BlazorAppCrud.Models.ViewModels;

public class UpdateUserModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your username")]
    public string? UserName { get; set; }
    
    [Required(AllowEmptyStrings = true, ErrorMessage = "Please enter your email")]
    public string? Password { get; set; }
    
    [Required(AllowEmptyStrings = true, ErrorMessage = "Please enter your role")]
    public string? Role { get; set; }
    
    [Required(AllowEmptyStrings = true, ErrorMessage = "Please enter your email")]
    public string? Email { get; set; }
}