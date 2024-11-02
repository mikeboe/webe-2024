using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlazorAppCrud.Models.Entities;

[Table("answers", Schema = "public")]
public class AnswersClass
{
    [Key]
    [Column("id")]
    public string Id { get; set; }

    [Column("question_id")]
    public string QuestionId { get; set; }

    [Column("answer")]
    public string Answer { get; set; }

    [Column("is_correct")]
    [JsonPropertyName("is_correct")]
    public bool IsCorrect { get; set; }
    
    [Column("questions_class_id")]
    public string QuestionsClassId { get; set; }
}

public class AnswerData
{
    public string answer { get; set; }
    public bool is_correct { get; set; }
}