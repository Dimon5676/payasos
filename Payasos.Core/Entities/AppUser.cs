using Microsoft.AspNetCore.Identity;

namespace Payasos.Core.Entities;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string SecondName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public Role? Role { get; set; }
    public Organization Organization { get; set; } = null!;
    public bool IsAdmin { get; set; } = false;
}