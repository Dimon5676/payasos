using Microsoft.AspNetCore.Identity;
using Payasos.Core.Entities;
using Payasos.Core.Repositories;
using Payasos.Core.ViewModels;

namespace Payasos.Core.Services;

public class UserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IOrganisationRepository _organisationRepository;

    public UserService(UserManager<AppUser> userManager,
        IOrganisationRepository organisationRepository)
    {
        _userManager = userManager;
        _organisationRepository = organisationRepository;
    }

    public async Task<AppUser> RegisterUser(RegisterUserViewModel viewModel)
    {
        var org = _organisationRepository.GetOrganisationByCode(viewModel.Code);
        if (org == null) throw new Exception("Organisation not found");
        var user = new AppUser
        {
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            SecondName = viewModel.SecondName,
            Email = viewModel.Email,
            IsAdmin = false,
            UserName = viewModel.Email,
            Organization = org
        };
        var result = await _userManager.CreateAsync(user, viewModel.Password);
        if (!result.Succeeded) throw new Exception(String.Join(", ", result.Errors.Select(e => e.Description)));
        return user;
    }
    
    public async Task<Organization> RegisterOrganisation(RegisterOrganisationViewModel viewModel)
    {
        var rand = new Random();
        var user = new AppUser
        {
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            SecondName = viewModel.SecondName,
            Email = viewModel.Email,
            IsAdmin = true,
            UserName = viewModel.Email,
            Organization = new Organization
            {
                Name = viewModel.OrganisationName,
                Code = "" + (char)rand.Next('A', 'Z') + rand.Next(0, 10) + (char)rand.Next('A', 'Z') + rand.Next(0, 10)
            } 
        };
        var result = await _userManager.CreateAsync(user, viewModel.Password);
        if (!result.Succeeded) throw new Exception(String.Join(", ", result.Errors.Select(e => e.Description)));
        return user.Organization;
    }

    public IEnumerable<UserViewModel> GetUsers()
    {
        return _userManager.Users.Select(e => new UserViewModel
        {
            Email = e.Email,
            FirstName = e.FirstName,
            LastName = e.LastName,
            SecondName = e.SecondName,
            IsAdmin = e.IsAdmin
        });
    }
}