using BLL.Services;
using DAL;
using DAL.Entities.Context;
using DAL.Repositories;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

//Console.WriteLine("DB_PASSWORD = " + Environment.GetEnvironmentVariable("DB_PASSWORD"));
//Console.WriteLine("DB_PORT = [" + Environment.GetEnvironmentVariable("DB_PORT") + "]");

// Build connection string from env
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME");
var dbPass = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString =
    $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPass}";

// Controllers & OpenAPI
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// BLL services
builder.Services.AddScoped<GameService>();
builder.Services.AddScoped<TeamService>();
builder.Services.AddScoped<PlayerService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<OrganizationService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<MatchService>();

// DAL repositories
builder.Services.AddScoped<GameRepo>();
builder.Services.AddScoped<TeamRepo>();
builder.Services.AddScoped<RoleRepo>();
builder.Services.AddScoped<OrganizationRepo>();
builder.Services.AddScoped<PlayerRepo>();
builder.Services.AddScoped<AuthRepo>();
builder.Services.AddScoped<MatchRepo>();
builder.Services.AddScoped<MatchResultRepo>();


builder.Services.AddScoped<DataAccessFactory>();

// DbContext (CORRECT)
builder.Services.AddDbContext<ETMSContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
