using System.ComponentModel.DataAnnotations;

namespace Payasos.Core.ViewModels;

public class RegisterViewModel
{
    [Required]
    public string FirstName { get; set; } = null!;
    
    [Required]
    public string LastName { get; set; } = null!;

    public string? SecondName { get; set; }

    [Required]
    public string Email { get; set; } = null!;

    [Required] public string Password { get; set; } = null!;
}