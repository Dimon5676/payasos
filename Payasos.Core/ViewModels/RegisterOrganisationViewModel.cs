using System.ComponentModel.DataAnnotations;

namespace Payasos.Core.ViewModels;

public class RegisterOrganisationViewModel : RegisterViewModel
{
    [Required(ErrorMessage = "Организация не может быть без названия")]
    [MinLength(2, ErrorMessage = "Название организации не может быть меньше 2х символов")]
    [MaxLength(30, ErrorMessage = "Название организации не может быть больше 30 символов")]
    public string OrganisationName { get; set; } = null!;
    
    [Required(ErrorMessage = "В организации должна быть стандартная роль")]
    [MinLength(3, ErrorMessage = "Роль не может быть меньше 3х символов")]
    [MaxLength(30, ErrorMessage = "Роль не может быть больше 30 символов")]
    public string DefaultRole { get; set; }
}