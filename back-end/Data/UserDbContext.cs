using Efficiency.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Efficiency.Data;

public class UserDbContext : IdentityDbContext<User>
{
    private IConfiguration _config;

    public UserDbContext(DbContextOptions<UserDbContext> opt, IConfiguration config) : base(opt)
    {
        _config = config;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}