using System;
using System.Diagnostics;
using System.Text.Json;
using Isopoh.Cryptography.Argon2;
using BlazorAppCrud.Data;
using BlazorAppCrud.Models.Entities;
using Microsoft.EntityFrameworkCore;
using OpenAI.Chat;

namespace BlazorAppCrud.Services;

public class QuestionsService
{
    protected readonly ApplicationDbContext _dbcontext;

    public QuestionsService( ApplicationDbContext _db)
    {
        _dbcontext = _db;
    }

    // Get all questions
    public List<QuestionsClass> GetQuestions()
    {
        return _dbcontext.Questions.ToList();
    }

    // Get all Questions by TopicId
    public List<QuestionsClass> GetQuestionsByTopicId(string id)
    {
        return _dbcontext.Questions.Where(u => u.TopicId == id).ToList();
    }   
    // For test, get by topic Id, sort randomly, and take 5. Join with Answers
    public List<QuestionsClass> GetTestQuestionsByTopicId(string id, int count)
    {
        var questions = _dbcontext
            .Questions
            .Where(u => u.TopicId == id)
            .OrderBy(u => Guid.NewGuid())
            .Take(count)
            .Include(q => q.Answers)
            .ToList();
        
        return questions;
    }


    // Get question by id 
    public QuestionsClass GetQuestionById(string id)
    {
        return _dbcontext.Questions.FirstOrDefault(u => u.Id == id);
    }
    
    
    // Add new question
    public string InsertRecord(QuestionsClass question)
    {
        Trace.WriteLine("✅ Inserting Record");
        var id = System.Guid.NewGuid();
        question.Id = id.ToString();
        
        _dbcontext.Questions.Add(question);
        _dbcontext.SaveChanges();
        return id.ToString();
    }

    // Edit Record
    public QuestionsClass EditRecord(string id)
    {
        QuestionsClass question = new QuestionsClass();

        return _dbcontext.Questions.FirstOrDefault(u => u.Id == id);
    }
    
    // generate with ai
    public async Task GenerateQuestions(string topicId)
    {
        Trace.WriteLine("✅ Generating Record");
    // get topic 
    var topic = _dbcontext.Topics.FirstOrDefault(u => u.Id == topicId);

    // create question
    ChatClient chatClient = new ChatClient("gpt-4o", apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY") );

    var prompt = "Don't use any formatting, just seind plain json. NO MARKDOWN. Generate a JSON array of 5 quiz questions, each with a question string and 4 answers in an array. Each answer should be an object with the answer string and a boolean \"is_correct\" field. Only one answer should be correct per question. The questions should be about the topic:" + topic.Title + ", with the description: " + topic.Description;

    ChatCompletion completion = chatClient.CompleteChat(prompt);

    Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");

    // parse json into List of Questions 
    var json = completion.Content[0].Text;
    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true // This is the key to ignore case differences
    };

    // Deserialize into List<QuestionData>
    var generatedRawQuestions = JsonSerializer.Deserialize<List<QuestionData>>(json, options);

    foreach (QuestionData qData in generatedRawQuestions)
    {
        var question = new QuestionsClass
        {
            Id = System.Guid.NewGuid().ToString(),
            TopicId = topicId,
            Question = qData.question,
            Answers = new List<AnswersClass>() // Initialize the Answers list
        };

        // Add Answers to the database
        foreach (AnswerData aData in qData.answers)
        {
            var answer = new AnswersClass
            {
                Id = System.Guid.NewGuid().ToString(),
                QuestionId = question.Id,
                Answer = aData.answer,
                IsCorrect = aData.is_correct
            };

            question.Answers.Add(answer);
            Console.WriteLine(question.Answers.ToString());
            
            _dbcontext.Answers.Add(answer);
        }
        
        _dbcontext.Questions.Add(question);
    }

    _dbcontext.SaveChanges();
    }

    // Update Record
    // public bool UpdateRecord(UserClass user)
    // {
    //     var userRecUpdate = _dbcontext.Users.FirstOrDefault(u => u.Id == user.Id);
    //     if (userRecUpdate != null)
    //     {
    //         userRecUpdate.UserName = user.UserName;
    //         userRecUpdate.Email = user.Email;
    //         userRecUpdate.Role = user.Role;
    //         
    //         _dbcontext.SaveChanges();
    //     }
    //     else
    //     {
    //         return false;
    //     }
    //     return true;
    // }

    public bool DeleteRecord(string id)
    {
        Trace.WriteLine("Deleting Record");
        var questionRecDelete = _dbcontext.Questions.FirstOrDefault(u => u.Id == id);
        if (questionRecDelete != null)
        {
            _dbcontext.Questions.Remove(questionRecDelete);
            _dbcontext.SaveChanges();
        }
        else
        {
            return false;
        }
        return true;
    }


}
