using System;
using System.Diagnostics;
using Isopoh.Cryptography.Argon2;
using BlazorAppCrud.Data;
using BlazorAppCrud.Models.Entities;

namespace BlazorAppCrud.Services;

public class AnswersService
{
    protected readonly ApplicationDbContext _dbcontext;

    public AnswersService( ApplicationDbContext _db)
    {
        _dbcontext = _db;
    }

    // Get all answers
    public List<AnswersClass> GetAnswers()
    {
        return _dbcontext.Answers.ToList();
    }

    // Get answers by question id
    public List<AnswersClass> GetAnswersByQuestionId(string id)
    {
        return _dbcontext.Answers.Where(u => u.QuestionId == id).ToList();
    }
    
    // Get answer by id
    public AnswersClass GetAnswerById(string id)
    {
        return _dbcontext.Answers.FirstOrDefault(u => u.Id == id);
    }

    // Add new topic
    public string InsertRecord(AnswersClass answer)
    {
        Trace.WriteLine("✅ Inserting Record");
        var id = System.Guid.NewGuid();
        answer.Id = id.ToString();
        
        _dbcontext.Answers.Add(answer);
        _dbcontext.SaveChanges();
        return id.ToString();
    }

    // Edit Record
    public AnswersClass EditRecord(string id)
    {
        AnswersClass answer = new AnswersClass();

        return _dbcontext.Answers.FirstOrDefault(u => u.Id == id);
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
        var answerRecDelete = _dbcontext.Topics.FirstOrDefault(u => u.Id == id);
        if (answerRecDelete != null)
        {
            _dbcontext.Topics.Remove(answerRecDelete);
            _dbcontext.SaveChanges();
        }
        else
        {
            return false;
        }
        return true;
    }


}
