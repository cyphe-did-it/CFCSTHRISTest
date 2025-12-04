
using HRIS.Application.Employees.Commands.CreateEmployee;
using HRIS.Infrastructure;
using HRIS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("HRISDb"); // Add connection string configuration

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }
);  // added controller with enum string converter


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

// Register DbContext with SQL Server provider
builder.Services.AddDbContext<HRISDbContext>(options =>
    options.UseSqlServer(connectionString));

// Services:
builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(CreateEmployeeCommand).Assembly));


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
