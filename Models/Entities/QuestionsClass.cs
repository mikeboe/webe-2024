using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlazorAppCrud.Models.Entities;

[Table("questions", Schema = "public")]
public class QuestionsClass
{
    [Key]
    [Column("id")]
    public string Id { get; set; }

    [Column("topic_id")]
    public string TopicId { get; set; }

    [Column("question")]
    [JsonPropertyName("question")]
    public string Question { get; set; }

    public List<AnswersClass>? Answers { get; set; }
}

public class QuestionData
{
    public string question { get; set; }
    public List<AnswerData> answers { get; set; }
}