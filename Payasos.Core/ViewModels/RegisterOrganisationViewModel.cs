using System.ComponentModel.DataAnnotations;

namespace Payasos.Core.ViewModels;

public class RegisterOrganisationViewModel : RegisterViewModel
{
    [Required]
    public string OrganisationName { get; set; } = null!;
}