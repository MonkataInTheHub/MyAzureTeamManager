using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAzureTeamManager.Tests
{
    internal class Utils
    {
        public static DbContextOptions<MyAzureTeamManagerDbContext> GetOptions(string nameOfDb)
        {
            return new DbContextOptionsBuilder<MyAzureTeamManagerDbContext>()
                .UseInMemoryDatabase(databaseName: nameOfDb)
                .EnableSensitiveDataLogging()
                .Options;
        }
        public static void Seed(MyAzureTeamManagerDbContext context)
        {
            var people = new Person[]
            {
                new Person
                {
                    FirstName ="Ivo",
                    LastName = "Babankata",
                    Age = 17,
                    TeamId = 1,
                },
                new Person
                {
                    FirstName ="Gosho",
                    LastName = "Streleca",
                    Age = 21,
                    TeamId = 2,
                },
                new Person
                {
                    FirstName ="Kiro",
                    LastName = "Krushata",
                    Age = 38,
                    TeamId = 3,
                },
            };
            var teams = new Team[]
            {
                new Team
                {
                    TeamName = "MahlenskiqOtbor"
                },
                new Team
                {
                    TeamName = "OtboraNaBiqchite"
                },
                new Team
                {
                    TeamName = "NayDobriqOtbor"
                }
            };
            var bugs = new Bug[]
            {
                new Bug
                {
                    Title = "Ne bachka programata",
                    Description = "Vkluchvam q i dava nqkakyv error",
                    BoardId = 1,
                    Priority = Priority.Low,
                    BugStatus = Status.New,
                    History = ""
                },
                new Bug
                {
                    Title = "Ima Greshka pri startirane",
                    Description = "Pri startirane ne se vkluchva ot pravilnoto mqsto",
                    BoardId = 2,
                    Priority = Priority.Medium,
                    BugStatus = Status.InProgress,
                    History = ""
                },
                new Bug
                {
                    Title = "Greshka pri zatvarqne",
                    Description = "Pri zatvarqne programata se restartira",
                    BoardId = 3,
                    Priority = Priority.High,
                    BugStatus = Status.Completed,
                    History = ""
                }
            };
            var boards = new Board[]
            {
                new Board(1)
                
            };
            var feedbacks = new Feedback[]
            {
                new Feedback
                {
                    Title = "Ne bachka programata",
                    Description = "Veche bachka",
                    FeedbackStatus = Status.Completed,
                    History = ""
                },
                new Feedback
                {
                    Title = "Ima Greshka pri startirane",
                    Description = "Veche startira pravilno",
                    FeedbackStatus = Status.Completed,
                    History = ""
                },
                new Feedback
                {
                    Title = "Greshka pri zatvarqne",
                    Description = "Restartiraneto e mahnato, no ne mojesh da q vkluchish pak do restartirane na komputyra",
                    FeedbackStatus = Status.InProgress,
                    History = ""
                },
            };
            var tasks = new Models.Task[]
            {
                new Models.Task
                {
                    Title = "Ne bachka programata",
                    Description = "Napravi q da bachka",
                    TaskStatus = Status.New,
                    History = ""
                },
                new Models.Task
                {
                    Title = "Ima Greshka pri startirane",
                    Description = "Opravi startiraneto",
                    TaskStatus = Status.New,
                    History = ""
                },
                new Models.Task
                {
                    Title = "Greshka pri zatvarqne",
                    Description = "Razberi zashto se restartira pri zatvarqne i ko gorigiray pri takava vyzmojnost",
                    TaskStatus = Status.New,
                    History = ""
                }
            };
            context.People.AddRange(people);
            context.Teams.AddRange(teams);
            context.Bugs.AddRange(bugs);
            context.Boards.AddRange(boards);
            context.Feedbacks.AddRange(feedbacks);
            context.Tasks.AddRange(tasks);

            context.SaveChanges();
        }
    }
}
