using BLL.Services;

using DAL;
using DAL.Entities.Context;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//services ->BLL
builder.Services.AddScoped<GameService>();
builder.Services.AddScoped<TeamService>();

//repo ->DAL
builder.Services.AddScoped<GameRepo>();
builder.Services.AddScoped<TeamRepo>();


//DataAccessFactory
builder.Services.AddScoped<DataAccessFactory>();

builder.Services.AddDbContext<UMSContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConn")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
