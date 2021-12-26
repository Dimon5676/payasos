using System.ComponentModel.DataAnnotations;

namespace Payasos.Core.ViewModels;

public class RegisterUserViewModel : RegisterViewModel
{
    [Required(ErrorMessage = "Введите пригласительный код")] 
    public string Code { get; set; } = null!;
}