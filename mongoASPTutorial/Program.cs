using Microsoft.Extensions.Options;
using mongoASPTutorial.Models;
using mongoASPTutorial.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Tell our project to get the settings from our settings.json and map to class
builder.Services.Configure<StudentStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(StudentStoreDatabaseSettings)));

// Associate the interface with the class for DB settings
builder.Services.AddSingleton<IStudentStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<StudentStoreDatabaseSettings>>().Value);

// Specify to the mongo client our DB connection string from settings.json
builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("StudentStoreDatabaseSettings:ConnectionString")));

// Associate the interface with the class for our student service
builder.Services.AddScoped<IStudentService, StudentService>();

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
