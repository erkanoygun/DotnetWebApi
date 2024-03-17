using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MyApp.DBOperation;
using MyApp.DBOperations;
using MyApp.MiddleWares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookStoreDBContext>(options => options.UseInMemoryDatabase(databaseName: "BookStoreDB"));
builder.Services.AddScoped<IBookStoreDBContext>(provider => provider.GetService<BookStoreDBContext>()!);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
}

app.UseCustomExceptionMiddle();

app.Run();
