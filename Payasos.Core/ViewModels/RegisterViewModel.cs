using System.ComponentModel.DataAnnotations;

namespace Payasos.Core.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Поле имя не может быть пустым")]
    [MinLength(2, ErrorMessage = "Имя не может быть меньше 2х символов")]
    [MaxLength(30, ErrorMessage = "Имя не может быть больше 30 символов")]
    public string FirstName { get; set; } = null!;
    
    [Required(ErrorMessage = "Поле фамилия не может быть пустым")]
    [MinLength(2, ErrorMessage = "Фамилия не может быть меньше 2х символов")]
    [MaxLength(30, ErrorMessage = "Фамилия не может быть больше 30 символов")]
    public string LastName { get; set; } = null!;

    [MinLength(2, ErrorMessage = "Отчество не может быть меньше 2х символов")]
    [MaxLength(30, ErrorMessage = "Отчество не может быть больше 30 символов")]
    public string? SecondName { get; set; }

    [Required(ErrorMessage = "Поле email не может быть пустым")]
    public string Email { get; set; } = null!;

    [Required] public string Password { get; set; } = null!;
}