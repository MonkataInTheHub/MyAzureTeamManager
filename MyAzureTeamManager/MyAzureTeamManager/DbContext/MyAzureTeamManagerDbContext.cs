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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().Ignore(t => t.Boards);
            modelBuilder.Entity<Team>().Ignore(t => t.Members);
            modelBuilder.Entity<Models.Task>().Ignore(t => t.Comments);
            modelBuilder.Entity<Feedback>().Ignore(f => f.Comments);
            modelBuilder.Entity<Bug>().Ignore(b => b.Comments);

        }
    }
}
