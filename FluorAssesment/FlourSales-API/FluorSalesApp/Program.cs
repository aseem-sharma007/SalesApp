using FluorSalesApp.Data;
using FluorSalesApp.Repository;
using FluorSalesApp.Repository.Interfaces;
using FluorSalesApp.Service;
using FluorSalesApp.Service.Interfaces;
using Microsoft.EntityFrameworkCore; // Ensure this using directive is present
using System;

// Add the required NuGet package for SQL Server support in Entity Framework Core
// Run the following command in the Package Manager Console or terminal:
// Install-Package Microsoft.EntityFrameworkCore.SqlServer

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FluorAppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:4200") // ?? Angular dev server
                         .AllowAnyHeader()
                         .AllowAnyMethod());
});

builder.Services.AddScoped<ISalesRepRepository, SalesRepRepository>();
builder.Services.AddScoped<ISalesRepService, SalesRepService>();

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
//enable Swagger in Production too 
 app.UseSwagger();
 app.UseSwaggerUI();

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
