namespace Payasos.Core.ViewModels;

public class UserViewModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string SecondName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool IsAdmin { get; set; } = false!;
}