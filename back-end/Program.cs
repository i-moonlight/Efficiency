/*
    necessary packages to this project:
        - Microsoft.EntityFrameworkCore -v 7.0.0
        - Microsoft.EntityFrameworkCore.Tools -v 7.0.0
        - Microsoft.EntityFrameworkCore.Relational -v 7.0.0
        - Pomelo.EntityFrameworkCore.MySql -v 6.0.2
        - AutoMapper -v 12.0.0
        - AutoMapper.Extensions.Microsoft.DependencyInjection -v 12.0.0
        - Microsoft.AspNetCore.Mvc.NewtonsoftJson -v 6.0.10 <IN CASE IT'S NECESSARY TO USE HTTP PATCH INSTEAD OF PUT>
        - Microsoft.EntityFrameworkCore.Proxies -v 6.0.7
        - Microsoft.AspNetCore.Identity --version 2.2.0

    necessary tools for this project:
        - dotnet-ef -v 7.0.0

    Console commands:
        - dotnet add package Microsoft.EntityFrameworkCore -v 6.0.7
        - dotnet add package Microsoft.EntityFrameworkCore.Tools -v 6.0.7
        - dotnet add package Microsoft.EntityFrameworkCore.Relational -v 6.0.7
        - dotnet add package Pomelo.EntityFrameworkCore.MySql -v 6.0.2
        - dotnet add package AutoMapper -v 12.0.0
        - dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection -v 12.0.0
        - dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson -v 6.0.10
        - dotnet add package Microsoft.EntityFrameworkCore.Proxies -v 6.0.7
        - dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
        - dotnet tool install --global dotnet-ef -v 7.0.0
        - dotnet ef migrations add <NomeDaMigration>
        - dotnet ef database update
*/

using Efficiency.Data;
using Efficiency.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("EfficiencyConnection");

builder.Services.AddDbContext<AppDbContext>(
    opts => opts
    .UseLazyLoadingProxies()
    .UseMySql(
        connectionString, 
        ServerVersion.AutoDetect(connectionString)
    )
);

builder.Services.AddDbContext<UserDbContext>(
    opts => opts
    .UseLazyLoadingProxies()
    .UseMySql(
        connectionString, 
        ServerVersion.AutoDetect(connectionString)
    )
);

builder.Services.AddControllers();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<UserService, UserService>();


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
