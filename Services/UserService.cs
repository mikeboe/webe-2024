using System;
using System.Diagnostics;
using Isopoh.Cryptography.Argon2;
using BlazorAppCrud.Data;
using BlazorAppCrud.Models.Entities;

namespace BlazorAppCrud.Services;

public class UserService
{
    protected readonly ApplicationDbContext _dbcontext;

    public UserService( ApplicationDbContext _db)
    {
        _dbcontext = _db;
    }
    
    // Get user Role
    public string GetUserRole(string userName)
    {
        var user = _dbcontext.Users.FirstOrDefault(x => x.UserName == userName);
        return user.Role;
    }

    // Get all users
    public List<UserClass> GetUsers()
    {
        return _dbcontext.Users.ToList();
    }

    // Get user by ID
    public UserClass GetUserById(string id)
    {
        return _dbcontext.Users.FirstOrDefault(x => x.Id == id);
    }

    // Add new user
    public bool InsertRecord(UserClass user)
    {
        Trace.WriteLine("✅ Inserting Record");
        var id = System.Guid.NewGuid();
        user.Id = id.ToString();
        
        // hash pw
        user.Password = Argon2.Hash(user.Password);
        
        _dbcontext.Users.Add(user);
        _dbcontext.SaveChanges();
        return true;
    }

    // Edit Record
    public UserClass EditRecord(string id)
    {
        UserClass user = new UserClass();

        return _dbcontext.Users.FirstOrDefault(u => u.Id == id);
    }

    // Update Record
    public bool UpdateRecord(UserClass user)
    {
        var userRecUpdate = _dbcontext.Users.FirstOrDefault(u => u.Id == user.Id);
        if (userRecUpdate != null)
        {
            userRecUpdate.UserName = user.UserName;
            userRecUpdate.Email = user.Email;
            userRecUpdate.Role = user.Role;
            
            _dbcontext.SaveChanges();
        }
        else
        {
            return false;
        }
        return true;
    }

    public bool DeleteRecord(string id)
    {
        Trace.WriteLine("Deleting Record");
        var userRecDelete = _dbcontext.Users.FirstOrDefault(u => u.Id == id);
        if (userRecDelete != null)
        {
            _dbcontext.Users.Remove(userRecDelete);
            _dbcontext.SaveChanges();
        }
        else
        {
            return false;
        }
        return true;
    }


}
