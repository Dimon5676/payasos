using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Payasos.Core.Entities;

namespace Payasos.Infrastructure;

public class AppDbContext : IdentityDbContext<AppUser>
{
    
}