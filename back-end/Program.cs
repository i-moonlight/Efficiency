/*
    necessary packages to this project:
        - Microsoft.EntityFrameworkCore
        - Microsoft.EntityFrameworkCore.Relational
        - Microsoft.EntityFrameworkCore.Proxies
        - Microsoft.EntityFrameworkCore.Tools
        - Pomelo.EntityFrameworkCore.MySql
        - AutoMapper
        - AutoMapper.Extensions.Microsoft.DependencyInjection
        - Microsoft.AspNetCore.Mvc.NewtonsoftJson 
        - ☝🏻 <IN CASE IT'S NECESSARY TO USE HTTP PATCH INSTEAD OF PUT>
        - Microsoft.AspNetCore.Identity.EntityFrameworkCore
        - Microsoft.AspNetCore.Identity.Stores
        - Microsoft.AspNetCore.Identity.UI
        - FluentResults

    necessary tools for this project:
        - dotnet-ef -v 7.0.0

    Console commands:
        - dotnet add package Microsoft.EntityFrameworkCore -v 6.0.7
        - dotnet add package Microsoft.EntityFrameworkCore.Relational -v 6.0.7
        - dotnet add package Microsoft.EntityFrameworkCore.Proxies -v 6.0.7
        - dotnet add package Microsoft.EntityFrameworkCore.Tools -v 6.0.7
        - dotnet add package Pomelo.EntityFrameworkCore.MySql -v 6.0.2
        - dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 6.0.7
        - dotnet add package Microsoft.AspNetCore.Identity.Stores -v 6.0.7
        - dotnet add package Microsoft.AspNetCore.Identity.UI -v 6.0.7
        - dotnet add package AutoMapper -v 12.0.0
        - dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection -v 12.0.0
        - dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson -v 6.0.10
        - ☝🏻 <IN CASE IT'S NECESSARY TO USE HTTP PATCH INSTEAD OF PUT>
        - dotnet add package FluentResults --version 3.15.1
        - dotnet tool install --global dotnet-ef -v 7.0.0
        - dotnet ef migrations add <NomeDaMigration>
        - dotnet ef database update
*/

using Efficiency.Models;
using Efficiency.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("EfficiencyConnection");

builder.Services.AddDbContext<AppDbContext>
(
    opts => opts
    .UseLazyLoadingProxies()
    .UseMySql(
        connectionString, 
        ServerVersion.AutoDetect(connectionString)
    )
);

builder.Services.AddDefaultIdentity<User>
(
    options => options.SignIn.RequireConfirmedAccount = true
).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<UserService, UserService>();
builder.Services.AddScoped<CompanyService, CompanyService>();
builder.Services.AddScoped<EmployeeService, EmployeeService>();
builder.Services.AddScoped<FinancialResultService, FinancialResultService>();
builder.Services.AddScoped<FinancialServiceService, FinancialServiceService>();
builder.Services.AddScoped<EmployeeFinancialResultService, EmployeeFinancialResultService>();


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
