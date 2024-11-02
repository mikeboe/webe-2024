using System;
using System.Diagnostics;
using Isopoh.Cryptography.Argon2;
using BlazorAppCrud.Data;
using BlazorAppCrud.Models.Entities;

namespace BlazorAppCrud.Services;

public class TopicsService
{
    protected readonly ApplicationDbContext _dbcontext;

    public TopicsService( ApplicationDbContext _db)
    {
        _dbcontext = _db;
    }

    // Get all topics
    public List<TopicClass> GetTopics()
    {
        return _dbcontext.Topics.ToList();
    }

    // Get topic by ID
    public TopicClass GetTopicById(string id)
    {
        return _dbcontext.Topics.FirstOrDefault(x => x.Id == id);
    }

    // Add new topic
    public string InsertRecord(TopicClass topic)
    {
        Trace.WriteLine("✅ Inserting Record");
        var id = System.Guid.NewGuid();
        topic.Id = id.ToString();
        
        _dbcontext.Topics.Add(topic);
        _dbcontext.SaveChanges();
        return id.ToString();
    }

    // Edit Record
    public TopicClass EditRecord(string id)
    {
        TopicClass topic = new TopicClass();

        return _dbcontext.Topics.FirstOrDefault(u => u.Id == id);
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
        var topicRecDelete = _dbcontext.Topics.FirstOrDefault(u => u.Id == id);
        if (topicRecDelete != null)
        {
            _dbcontext.Topics.Remove(topicRecDelete);
            _dbcontext.SaveChanges();
        }
        else
        {
            return false;
        }
        return true;
    }


}
