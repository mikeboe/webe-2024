using Isopoh.Cryptography.Argon2;
using BlazorAppCrud.Data;
using BlazorAppCrud.Models.Entities;

namespace BlazorAppCrud.Services;

public class AuthService
{
    protected readonly ApplicationDbContext _dbcontext;

    public AuthService( ApplicationDbContext _db)
    {
        _dbcontext = _db;
    }
    
    // Authenticate User by UserName and Password
    public UserClass AuthenticateUser(string userName, string password)
    {
        Console.WriteLine("🔐 Authenticating User");
        // hash password
        var hashedPassword = Argon2.Hash(password);
        
        // check if user exists
        var user = _dbcontext.Users.FirstOrDefault(x => x.UserName == userName);
            
        if (user == null)
        {
            throw new Exception("User or Password is incorrect");
        }
        
        // check if password is correct
        Console.WriteLine("🔐 Checking Password");
        // Console.WriteLine(hashedPassword);
        // Console.WriteLine(user.password);

        var matches = Argon2.Verify(user.Password, password);
        
        if (!matches)
        {
            
            throw new Exception("User or Password is incorrect");
        }
        Console.WriteLine("Password is correct");
        Console.WriteLine("🔐 User Authenticated as " + user.UserName + " with role " + user.Role);
        return user;
    }
}