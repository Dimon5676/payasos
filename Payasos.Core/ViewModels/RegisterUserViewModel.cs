using System.ComponentModel.DataAnnotations;

namespace Payasos.Core.ViewModels;

public class RegisterUserViewModel : RegisterViewModel
{
    [Required] 
    public string Code { get; set; } = null!;
}