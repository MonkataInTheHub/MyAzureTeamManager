using MyAzureTeamManager;
using MyAzureTeamManager.Models;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using MyAzureTeamManager.Services;
using MyAzureTeamManager.ServiceInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyAzureTeamManagerDbContext>(options => options.UseSqlServer("server=.;database=MyAzureTeamManagerDb;Trusted_Connection=True;"));

builder.Services.AddScoped<IBoardService, BoardService>();
builder.Services.AddScoped<IBugService, BugService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
