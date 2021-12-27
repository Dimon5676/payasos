namespace Payasos.Core.ViewModels;

public class UserViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SecondName { get; set; }
    
    public string Role { get; set; }
    public string Email { get; set; }
    public bool IsAdmin { get; set; }
}