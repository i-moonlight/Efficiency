// https://stackoverflow.com/questions/38019808/entity-framework-core-ef-7-many-to-many-results-always-null

using Efficiency.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
{
    public DbSet<Store>? Stores { get; set; }
    public DbSet<Seller>? Sellers { get; set; }
    public DbSet<Result>? Results { get; set; }
    public DbSet<Service>? Services { get; set; }
    public DbSet<ServiceResult>? ServicesResult { get; set; }
    public DbSet<ServiceGoal>? ServicesGoal { get; set; }
    public DbSet<Goal>? Goals { get; set; }
    private IConfiguration _config;

    public AppDbContext(IConfiguration config)
    {
        _config = config;
    }

    public AppDbContext(
        DbContextOptions<AppDbContext> opts,
        IConfiguration config
    ) : base(opts)
    {
        _config = config;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // n:1 relationship between users and store
        builder.Entity<User>()
            .HasOne(user => user.Store)
            .WithMany(store => store.Users)
            .HasPrincipalKey(store => store.ID)
            .HasForeignKey(user => user.StoreID);

        // 1:n relationship between store and sellers
        builder.Entity<Seller>()
            .HasOne(seller => seller.Store)
            .WithMany(store => store.Sellers)
            .HasPrincipalKey(store => store.ID)
            .HasForeignKey(seller => seller.StoreID);

        // n:1 relationship between sellers and store
        builder.Entity<Seller>()
            .HasOne(seller => seller.Store)
            .WithMany(store => store.Sellers)
            .HasPrincipalKey(store => store.ID)
            .HasForeignKey(seller => seller.StoreID);

        // 1:n relationship between store and goals
        builder.Entity<Goal>()
            .HasOne(goal => goal.Store)
            .WithMany(store => store.Goals)
            .HasPrincipalKey(store => store.ID)
            .HasForeignKey(goal => goal.StoreID);

        // 1:n relationship between seller and results        
        builder.Entity<Result>()
            .HasOne(result => result.Seller)
            .WithMany(seller => seller.Results)
            .HasPrincipalKey(seller => seller.ID)
            .HasForeignKey(result => result.SellerID);

        // Creating a default admin user
        User admin = new User
        {
            Id = 9999,
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            SubscriptionType = Subscription.Lifetime,
            SubscriptionBegin = DateTime.UtcNow,
            SubscriptionExpiration = DateTime.MaxValue,
            FirstLogin = true,
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        PasswordHasher<User> hasher = new PasswordHasher<User>();

        admin.PasswordHash = hasher.HashPassword(admin,
            _config.GetValue<string>("admin:password"));

        builder.Entity<User>().HasData(admin);

        /*
        builder.Entity<IdentityRole<int>>().HasData(
            new IdentityRole<int>
            {
                Id = 1,
                Name = "admin",
                NormalizedName = "ADMIN"
            }
        );

        builder.Entity<IdentityRole<int>>().HasData(
            new IdentityRole<int>
            {
                Id = 2,
                Name = "regular",
                NormalizedName = "REGULAR"
            }
        );

        builder.Entity<IdentityUserRole<int>>().HasData(
            new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = 9999
            }
        );
        */

        // n:n relationship between Service and Result
        builder.Entity<ServiceResult>()
            .HasKey(serviceResult => new { serviceResult.ResultID, serviceResult.ServiceID });
        builder.Entity<ServiceResult>()
            .HasOne(serviceResult => serviceResult.Result)
            .WithMany(result => result.ResultsServices)
            .HasForeignKey(serviceResult => serviceResult.ResultID);
        builder.Entity<ServiceResult>()
            .HasOne(serviceResult => serviceResult.Service)
            .WithMany(service => service.ServicesResult)
            .HasForeignKey(serviceResult => serviceResult.ServiceID);

        // n:n relationship between Service and Goal
        builder.Entity<ServiceGoal>()
            .HasKey(serviceGoal => new { serviceGoal.GoalID, serviceGoal.ServiceID });
        builder.Entity<ServiceGoal>()
            .HasOne(serviceGoal => serviceGoal.Service)
            .WithMany(service => service.ServicesGoal)
            .HasForeignKey(serviceGoal => serviceGoal.ServiceID);
        builder.Entity<ServiceGoal>()
            .HasOne(serviceGoal => serviceGoal.Goal)
            .WithMany(goal => goal.ServicesGoal)
            .HasForeignKey(serviceGoal => serviceGoal.GoalID);

        /*
        // n:n relationship between Seller and Result
        // this relationship isn't used anymore. It will remain
        // in the code only for future reference
            builder.Entity<SellerResult>()
                .HasKey(efresult => efresult.ID);
            builder.Entity<SellerResult>()
                .HasOne(efresult => efresult.Seller)
                .WithMany(Seller => Seller.SellersResults)
                .HasForeignKey(efresult => efresult.SellerID);
            builder.Entity<SellerResult>()
                .HasOne(efresult => efresult.Result)
                .WithMany(fresult => fresult.SellersResults)
                .HasForeignKey(efresult => efresult.ResultID);
        */
    }

}