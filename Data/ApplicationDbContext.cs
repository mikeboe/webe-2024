using System.Configuration;
using Microsoft.EntityFrameworkCore;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace BlazorAppCrud.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<UserClass> Users { get; set; }
}