using System.ComponentModel.DataAnnotations;

namespace BlazorAppCrud.Models.ViewModels;

public class AddTopicModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the title")]
    public string? Title { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the description")]
    public string? Description { get; set; }
}