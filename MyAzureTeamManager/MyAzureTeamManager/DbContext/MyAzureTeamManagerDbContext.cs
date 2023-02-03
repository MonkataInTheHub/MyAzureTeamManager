using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Models;

namespace MyAzureTeamManager
{
    public class MyAzureTeamManagerDbContext : DbContext
    {
        public MyAzureTeamManagerDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
