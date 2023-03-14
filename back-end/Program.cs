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
        - Microsoft.AspNetCore.Authentication.JwtBearer
        - Microsoft.AspNetCore.Identity.Stores
        - Microsoft.AspNetCore.Identity.UI
        - System.IdentityModel.Tokens.Jwt
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
        - dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer -v 6.0.0
        - dotnet add package Microsoft.AspNetCore.Identity.Stores -v 6.0.7
        - dotnet add package Microsoft.AspNetCore.Identity.UI -v 6.0.7
        - dotnet add package System.IdentityModel.Tokens.Jwt --version 6.25.1
        - dotnet add package AutoMapper -v 12.0.0
        - dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection -v 12.0.0
        - dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson -v 6.0.10
        - ☝🏻 <IN CASE IT'S NECESSARY TO USE HTTP PATCH INSTEAD OF HTTP PUT>
        - dotnet add package FluentResults --version 3.15.1
        - dotnet tool install --global dotnet-ef -v 7.0.0
        - dotnet ef migrations add <NomeDaMigration>
        - dotnet ef database update

        USER SECRETS: https://learn.microsoft.com/pt-br/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows#register-the-user-secrets-configuration-source
*/

using System.Text;
using Efficiency.Models;
using Efficiency.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// string CORSPolicy = "AllowEverything";

builder.Services.AddAuthentication(
    opts => {
        opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
).AddJwtBearer(
    opts => {
        opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters 
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:7280",
            ValidAudience = "https://localhost:7280",
            // Loading secret from user secret "\AppData\Roaming\Microsoft\UserSecrets\af2e3685-21fa-47cc-977c-e304c4ab7998"
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
        };
    }
);

var connectionString = builder.Configuration["ConnectionStrings:EfficiencyConnection"];

builder.Services.AddDbContext<AppDbContext>
(
    opts => opts
    .UseLazyLoadingProxies()
    .UseMySql(
        connectionString, 
        ServerVersion.AutoDetect(connectionString)
    )
);

// builder.Services.AddCors( options => 
// {
//     options.AddPolicy(CORSPolicy, builder => builder
//         .AllowAnyHeader()
//         .AllowAnyMethod()
//         .AllowAnyOrigin()
//     );
// });

builder.Services.AddDefaultIdentity<User>
(
    options => options.SignIn.RequireConfirmedAccount = true
).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<UserService, UserService>();
builder.Services.AddScoped<TokenService, TokenService>();
builder.Services.AddScoped<CompanyService, CompanyService>();
builder.Services.AddScoped<EmployeeService, EmployeeService>();
builder.Services.AddScoped<FinancialResultService, FinancialResultService>();
builder.Services.AddScoped<FinancialServiceService, FinancialServiceService>();
builder.Services.AddScoped<EmployeeFinancialResultService, EmployeeFinancialResultService>();
builder.Services.AddScoped<FinancialResultFinancialServiceService, FinancialResultFinancialServiceService>();


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

app.UseCors( 
    builder => 
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    }
);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
