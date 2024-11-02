using System.Configuration;
using BlazorAppCrud.Models.Entities;
using Microsoft.EntityFrameworkCore;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace BlazorAppCrud.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<UserClass> Users { get; set; }
    
    public DbSet<TopicClass> Topics { get; set; }
    
    public DbSet<QuestionsClass> Questions { get; set; }
    
    public DbSet<AnswersClass> Answers { get; set; }
}