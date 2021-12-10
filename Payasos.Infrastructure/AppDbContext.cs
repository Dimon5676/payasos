using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Payasos.Core.Entities;

namespace Payasos.Infrastructure;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public DbSet<Organization> Organizations { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
}