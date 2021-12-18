using System.ComponentModel.DataAnnotations;

namespace Payasos.Core.ViewModels;

public class LoginViewModel
{
    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}