using System;
using System.Diagnostics;
using BlazorAppCrud.Data;

namespace BlazorAppCrud.Services;

public class UserService
{
    protected readonly ApplicationDbContext _dbcontext;

    public UserService( ApplicationDbContext _db)
    {
        _dbcontext = _db;
    }

    // Get all users
    public List<UserClass> GetUsers()
    {
        return _dbcontext.Users.ToList();
    }

    // Get user by ID
    public UserClass GetUserById(string id)
    {
        return _dbcontext.Users.FirstOrDefault(x => x.id == id);
    }

    // Add new user
    public bool InsertRecord(UserClass user)
    {
        Trace.WriteLine("✅ Inserting Record");
        var id = System.Guid.NewGuid();
        user.id = id.ToString();
        _dbcontext.Users.Add(user);
        _dbcontext.SaveChanges();
        return true;
    }

    // Edit Record
    public UserClass EditRecord(string id)
    {
        UserClass user = new UserClass();

        return _dbcontext.Users.FirstOrDefault(u => u.id == id);
    }

    // Update Record
    public bool UpdateRecord(UserClass user)
    {
        var userRecUpdate = _dbcontext.Users.FirstOrDefault(u => u.id == user.id);
        if (userRecUpdate != null)
        {
            userRecUpdate.userName = user.userName;
            userRecUpdate.email = user.email;
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
        var userRecDelete = _dbcontext.Users.FirstOrDefault(u => u.id == id);
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
