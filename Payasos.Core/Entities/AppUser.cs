using Microsoft.AspNetCore.Identity;

namespace Payasos.Core.Entities;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string? SecondName { get; set; }
    public string LastName { get; set; } = null!;
    public Role? Role { get; set; }
    public Organization Organization { get; set; } = null!;
    public bool IsAdmin { get; set; } = false;

    public string LastNameInitials =>
        SecondName != null
            ? LastName + " " + FirstName[0] + ". " + SecondName[0] + "."
            : LastName + " " + FirstName[0] + ".";
}