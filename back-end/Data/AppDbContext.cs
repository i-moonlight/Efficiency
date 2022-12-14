/**
https://stackoverflow.com/questions/38019808/entity-framework-core-ef-7-many-to-many-results-always-null

*/

using Efficiency.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<FinancialResult> FinancialResults { get; set; }
    public DbSet<FinancialService> FinancialServices { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<FinancialResultFinancialService> FResultsFServices { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> opts) : base (opts)
    {}

    protected override void OnModelCreating (ModelBuilder builder)
    {
        /*
        * n:1 relationship between user and company
        */
        builder.Entity<User>()
            .HasOne(user => user.Company)
            .WithMany(company => company.Users)
            .HasPrincipalKey(user => user.ID)
            .HasForeignKey(user => user.CompanyID);

        /*
        * n:1 relationship between employee and company
        */
        builder.Entity<Employee>()
            .HasOne(employee => employee.CompanyReference)
            .WithMany(company => company.Employees)
            .HasPrincipalKey(employee => employee.ID)
            .HasForeignKey(employee => employee.CompanyID);

        /*
        * n:n relationship between employee and financialresult
        */
        builder.Entity<Employee>()
            .HasMany(employee => employee.FinancialResults)
            .WithMany(fresult => fresult.Employees)
            .UsingEntity(join => join.ToTable("EmployeeFinancialResult"));

        /*
        * n:n relationship between financialresult and financialservice
        */
        builder.Entity<FinancialResultFinancialService>()
            .HasKey(frfs => new {frfs.FinancialResultID, frfs.FinancialServiceID});
        builder.Entity<FinancialResultFinancialService>()
            .HasOne(frfs => frfs.FinancialResult)
            .WithMany(fresult => fresult.FinancialResultsFinancialServices)
            .HasForeignKey(frfs => frfs.FinancialResultID);
        builder.Entity<FinancialResultFinancialService>()
            .HasOne(frfs => frfs.FinancialService)
            .WithMany(fservice => fservice.FinancialResultsFinancialServices)
            .HasForeignKey(frfs => frfs.FinancialServiceID);
    }

}