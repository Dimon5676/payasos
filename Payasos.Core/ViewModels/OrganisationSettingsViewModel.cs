using System.ComponentModel.DataAnnotations;
using Payasos.Core.Entities;

namespace Payasos.Core.ViewModels;

public class OrganisationSettingsViewModel
{
    [Required(ErrorMessage = "Организация не может быть без названия")]
    [MinLength(2, ErrorMessage = "Название организации не может быть меньше 2х символов")]
    [MaxLength(30, ErrorMessage = "Название организации не может быть больше 30 символов")]
    public string OrgName { get; set; }
    
    [Required(ErrorMessage = "Введите пригласительный код")] 
    [MinLength(4, ErrorMessage = "Пригласительный код не может быть меньше 4х символов")]
    [MaxLength(5, ErrorMessage = "Пригласительный код не может быть больше 5и символов")]
    public string InviteCode { get; set; }
    
    [Required(ErrorMessage = "У организации должна быть стандартная роль")]
    public int DefaultRoleId { get; set; }
    
    public Role SelectedRole { get; set; }
    public IEnumerable<Role> Roles { get; set; }
}