// https://stackoverflow.com/questions/38019808/entity-framework-core-ef-7-many-to-many-results-always-null

using Efficiency.Data;
using Efficiency.Models;
using Efficiency.Models.Enums;
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
    // Users are managed by identity
    private IConfiguration _config;

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

        // 1:n relationship between store and goals
        builder.Entity<Goal>()
            .HasOne(goal => goal.Store)
            .WithMany(store => store.Goals)
            .HasPrincipalKey(store => store.ID)
            .HasForeignKey(goal => goal.StoreID);

        // 1:n relationship between store and services
        builder.Entity<Service>()
            .HasOne(service => service.Store)
            .WithMany(store => store.Services)
            .HasPrincipalKey(store => store.ID)
            .HasForeignKey(service => service.StoreID);

        // 1:n relationship between seller and results        
        builder.Entity<Result>()
            .HasOne(result => result.Seller)
            .WithMany(seller => seller.Results)
            .HasPrincipalKey(seller => seller.ID)
            .HasForeignKey(result => result.SellerID);

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

        populateDataBase(builder, _config);
    }

    public void populateDataBase(ModelBuilder builder, IConfiguration config)
    {
        Store store = this.createStore();
        User admin = this.createAdminUser();
        ICollection<Goal> goals = this.createGoals();
        ICollection<Service> services = this.createServices();
        ICollection<ServiceGoal> servicesGoals = this.createServicesGoals();
        ICollection<Seller> sellers = this.createSellers();
        ICollection<Result> results = this.createResults();
        ICollection<ServiceResult> servicesResults = this.createServicesResults();

        builder.Entity<Store>().HasData(store);
        builder.Entity<User>().HasData(admin);

        foreach (Goal goal in goals)
        {
            builder.Entity<Goal>().HasData(goal);
        }
        foreach (Service service in services)
        {
            builder.Entity<Service>().HasData(service);
        }
        foreach (ServiceGoal serviceGoal in servicesGoals)
        {
            builder.Entity<ServiceGoal>().HasData(serviceGoal);
        }
        foreach (Seller seller in sellers)
        {
            builder.Entity<Seller>().HasData(seller);
        }
        foreach (Result result in results)
        {
            builder.Entity<Result>().HasData(result);
        }
        foreach (ServiceResult serviceResult in servicesResults)
        {
            builder.Entity<ServiceResult>().HasData(serviceResult);
        }
    }

    private User createAdminUser()
    {
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
            SecurityStamp = Guid.NewGuid().ToString(),
            Role = "ADMIN",
            StoreID = 1
        };

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

        PasswordHasher<User> hasher = new PasswordHasher<User>();

        admin.PasswordHash = hasher.HashPassword(
            admin,
            this._config.GetValue<string>("admin:password")
        );

        return admin;
    }

    private Store createStore()
    {
        Store store = new Store()
        {
            ID = 1,
            Name = "EFFICIENCY STORE",
            Country = "Brazil",
            State = "São Paulo",
            City = "São Paulo",
            Street = "Praça Maria Cândida Freitas de Oliveira, 18",
            District = "Mooca",
            Complement = "Prédio público",
            Observations = "This is where the observations should be inserted",
            ZipCode = "03168070"
        };
        return store;
    }

    private ICollection<Goal> createGoals()
    {
        Goal goal1 = new Goal()
        {
            ID = 1,
            StoreID = 1,
            Month = Month.September,
            Year = DateTime.Now.Year - 1,
            Value = 8481317.0
        };
        Goal goal2 = new Goal()
        {
            ID = 2,
            StoreID = 1,
            Month = Month.October,
            Year = DateTime.Now.Year - 1,
            Value = 7079055.0
        };
        Goal goal3 = new Goal()
        {
            ID = 3,
            StoreID = 1,
            Month = Month.November,
            Year = DateTime.Now.Year - 1,
            Value = 4581755.0
        };
        Goal goal4 = new Goal()
        {
            ID = 4,
            StoreID = 1,
            Month = Month.December,
            Year = DateTime.Now.Year - 1,
            Value = 6721971.0
        };
        Goal goal5 = new Goal()
        {
            ID = 5,
            StoreID = 1,
            Month = Month.January,
            Year = DateTime.Now.Year,
            Value = 8239781.0
        };
        Goal goal6 = new Goal()
        {
            ID = 6,
            StoreID = 1,
            Month = Month.February,
            Year = DateTime.Now.Year,
            Value = 1687245.0
        };
        Goal goal7 = new Goal()
        {
            ID = 7,
            StoreID = 1,
            Month = Month.March,
            Year = DateTime.Now.Year,
            Value = 6932877.0
        };
        Goal goal8 = new Goal()
        {
            ID = 8,
            StoreID = 1,
            Month = Month.April,
            Year = DateTime.Now.Year,
            Value = 7093967.0
        };

        List<Goal> goals = new List<Goal>()
        {
            goal1,
            goal2,
            goal3,
            goal4,
            goal5,
            goal6,
            goal7,
            goal8
        };

        return goals;
    }

    private ICollection<Service> createServices()
    {
        Service service1 = new Service()
        {
            ID = 1,
            StoreID = 1,
            Name = "Extended Guarantee"
        };
        Service service2 = new Service()
        {
            ID = 2,
            StoreID = 1,
            Name = "Techinical Insurance"
        };

        return new List<Service>(){
            service1,
            service2
        };
    }

    private ICollection<ServiceGoal> createServicesGoals()
    {
        ServiceGoal s1g1 = new ServiceGoal()
        {
            ServiceID = 1,
            GoalID = 1,
            Value = 676597
        };
        ServiceGoal s2g1 = new ServiceGoal()
        {
            ServiceID = 2,
            GoalID = 1,
            Value = 445315
        };
        ServiceGoal s1g2 = new ServiceGoal()
        {
            ServiceID = 1,
            GoalID = 2,
            Value = 912491
        };
        ServiceGoal s2g2 = new ServiceGoal()
        {
            ServiceID = 2,
            GoalID = 2,
            Value = 912491
        };
        ServiceGoal s1g3 = new ServiceGoal()
        {
            ServiceID = 1,
            GoalID = 3,
            Value = 549813
        };
        ServiceGoal s2g3 = new ServiceGoal()
        {
            ServiceID = 2,
            GoalID = 3,
            Value = 894390
        };
        ServiceGoal s1g4 = new ServiceGoal()
        {
            ServiceID = 1,
            GoalID = 4,
            Value = 472433
        };
        ServiceGoal s2g4 = new ServiceGoal()
        {
            ServiceID = 2,
            GoalID = 4,
            Value = 983652
        };
        ServiceGoal s1g5 = new ServiceGoal()
        {
            ServiceID = 1,
            GoalID = 5,
            Value = 237428
        };
        ServiceGoal s2g5 = new ServiceGoal()
        {
            ServiceID = 2,
            GoalID = 5,
            Value = 235060
        };
        ServiceGoal s1g6 = new ServiceGoal()
        {
            ServiceID = 1,
            GoalID = 6,
            Value = 131204
        };
        ServiceGoal s2g6 = new ServiceGoal()
        {
            ServiceID = 2,
            GoalID = 6,
            Value = 938524
        };
        ServiceGoal s1g7 = new ServiceGoal()
        {
            ServiceID = 1,
            GoalID = 7,
            Value = 877191
        };
        ServiceGoal s2g7 = new ServiceGoal()
        {
            ServiceID = 2,
            GoalID = 7,
            Value = 557740
        };
        ServiceGoal s1g8 = new ServiceGoal()
        {
            ServiceID = 1,
            GoalID = 8,
            Value = 500145
        };
        ServiceGoal s2g8 = new ServiceGoal()
        {
            ServiceID = 2,
            GoalID = 8,
            Value = 360438
        };

        return new List<ServiceGoal>(){
            s1g1,
            s2g1,
            s1g2,
            s2g2,
            s1g3,
            s2g3,
            s1g4,
            s2g4,
            s1g5,
            s2g5,
            s1g6,
            s2g6,
            s1g7,
            s2g7,
            s1g8,
            s2g8,
        };
    }

    private ICollection<Seller> createSellers()
    {
        Seller seller1 = new Seller()
        {
            ID = 1,
            StoreID = 1,
            Active = true,
            FirstName = "Tereza Carla",
            LastName = "Isabelly Lopes",
            Email = "tereza-lopes72@comdados.com",
            Phone = "81985172642",
            RegistrationNumber = 5170971
        };
        Seller seller2 = new Seller()
        {
            ID = 2,
            StoreID = 1,
            Active = true,
            FirstName = "Cláudia Sophia",
            LastName = "Luciana das Neves",
            Email = "claudia.sophia.dasneves@octagonbrasil.com.br",
            Phone = "84992669321",
            RegistrationNumber = 8377984
        };
        Seller seller3 = new Seller()
        {
            ID = 3,
            StoreID = 1,
            Active = true,
            FirstName = "Henry Guilherme",
            LastName = "Isaac Campos",
            Email = "henry.guilherme.campos@integrasjc.com.br",
            Phone = "42983716441",
            RegistrationNumber = 2054591
        };
        Seller seller4 = new Seller()
        {
            ID = 4,
            StoreID = 1,
            Active = true,
            FirstName = "Danilo Giovanni",
            LastName = "Dias",
            Email = "danilo_dias@marithimaconstrutora.com.br",
            Phone = "45996347291",
            RegistrationNumber = 2096378
        };
        Seller seller5 = new Seller()
        {
            ID = 5,
            StoreID = 1,
            Active = true,
            FirstName = "Jorge Mário José",
            LastName = "Farias",
            Email = "jorge_mario_farias@yool.com.br",
            Phone = "68983670574",
            RegistrationNumber = 1328623
        };

        List<Seller> sellers = new List<Seller>(){
            seller1,
            seller2,
            seller3,
            seller4,
            seller5
        };

        return sellers;
    }

    private ICollection<Result> createResults()
    {
        Random random = new Random();
        Result result1 = new Result()
        {
            ID = 1,
            SellerID = random.Next(1, 5),
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-random.Next(1, 365))),
            Value = 10574
        };
        Result result2 = new Result()
        {
            ID = 2,
            SellerID = random.Next(1, 5),
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-random.Next(1, 365))),
            Value = 12384
        };
        Result result3 = new Result()
        {
            ID = 3,
            SellerID = random.Next(1, 5),
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-random.Next(1, 365))),
            Value = 114443
        };
        Result result4 = new Result()
        {
            ID = 4,
            SellerID = random.Next(1, 5),
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-random.Next(1, 365))),
            Value = 1823
        };
        Result result5 = new Result()
        {
            ID = 5,
            SellerID = random.Next(1, 5),
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-random.Next(1, 365))),
            Value = 176370
        };
        Result result6 = new Result()
        {
            ID = 6,
            SellerID = random.Next(1, 5),
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-random.Next(1, 365))),
            Value = 147842
        };
        Result result7 = new Result()
        {
            ID = 7,
            SellerID = random.Next(1, 5),
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-random.Next(1, 365))),
            Value = 23805
        };
        Result result8 = new Result()
        {
            ID = 8,
            SellerID = random.Next(1, 5),
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-random.Next(1, 365))),
            Value = 156669
        };
        Result result9 = new Result()
        {
            ID = 9,
            SellerID = random.Next(1, 5),
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-random.Next(1, 365))),
            Value = 73181
        };
        Result result10 = new Result()
        {
            ID = 10,
            SellerID = random.Next(1, 5),
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-random.Next(1, 365))),
            Value = 124042
        };
        return new List<Result>(){
            result1,
            result2,
            result3,
            result4,
            result5,
            result6,
            result7,
            result8,
            result9,
            result10,
        };
    }

    private ICollection<ServiceResult> createServicesResults()
    {
        ServiceResult s1r1 = new ServiceResult()
        {
            ServiceID = 1,
            ResultID = 1,
            Value = 67784
        };
        ServiceResult s2r1 = new ServiceResult()
        {
            ServiceID = 2,
            ResultID = 1,
            Value = 173210
        };
        ServiceResult s1r2 = new ServiceResult()
        {
            ServiceID = 1,
            ResultID = 2,
            Value = 62121
        };
        ServiceResult s2r2 = new ServiceResult()
        {
            ServiceID = 2,
            ResultID = 2,
            Value = 12506
        };
        ServiceResult s1r3 = new ServiceResult()
        {
            ServiceID = 1,
            ResultID = 3,
            Value = 106495
        };
        ServiceResult s2r3 = new ServiceResult()
        {
            ServiceID = 2,
            ResultID = 3,
            Value = 12170
        };
        ServiceResult s1r4 = new ServiceResult()
        {
            ServiceID = 1,
            ResultID = 4,
            Value = 113523
        };
        ServiceResult s2r4 = new ServiceResult()
        {
            ServiceID = 2,
            ResultID = 4,
            Value = 173869
        };
        ServiceResult s1r5 = new ServiceResult()
        {
            ServiceID = 1,
            ResultID = 5,
            Value = 181087
        };
        ServiceResult s2r5 = new ServiceResult()
        {
            ServiceID = 2,
            ResultID = 5,
            Value = 106883
        };
        ServiceResult s1r6 = new ServiceResult()
        {
            ServiceID = 1,
            ResultID = 6,
            Value = 103405
        };
        ServiceResult s2r6 = new ServiceResult()
        {
            ServiceID = 2,
            ResultID = 6,
            Value = 197037
        };
        ServiceResult s1r7 = new ServiceResult()
        {
            ServiceID = 1,
            ResultID = 7,
            Value = 139618
        };
        ServiceResult s2r7 = new ServiceResult()
        {
            ServiceID = 2,
            ResultID = 7,
            Value = 36531
        };
        ServiceResult s1r8 = new ServiceResult()
        {
            ServiceID = 1,
            ResultID = 8,
            Value = 1906
        };
        ServiceResult s2r8 = new ServiceResult()
        {
            ServiceID = 2,
            ResultID = 8,
            Value = 1058
        };
        ServiceResult s1r9 = new ServiceResult()
        {
            ServiceID = 1,
            ResultID = 9,
            Value = 1215
        };
        ServiceResult s2r9 = new ServiceResult()
        {
            ServiceID = 2,
            ResultID = 9,
            Value = 1888
        };
        ServiceResult s1r10 = new ServiceResult()
        {
            ServiceID = 1,
            ResultID = 10,
            Value = 110
        };
        ServiceResult s2r10 = new ServiceResult()
        {
            ServiceID = 2,
            ResultID = 10,
            Value = 1312
        };

        return new List<ServiceResult>(){
            s1r1,
            s2r1,
            s1r2,
            s2r2,
            s1r3,
            s2r3,
            s1r4,
            s2r4,
            s1r5,
            s2r5,
            s1r6,
            s2r6,
            s1r7,
            s2r7,
            s1r8,
            s2r8,
            s1r9,
            s2r9,
            s1r10,
            s2r10,
        };
    }
}