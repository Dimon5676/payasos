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
    public async Task<IdentityResult> Register(RegisterViewModel viewModel)
    {
        var user = new AppUser
        {
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            SecondName = viewModel.SecondName,
            Email = viewModel.Email,
            IsAdmin = viewModel is RegisterOrganisationViewModel,
            UserName = viewModel.Email
        };
        var result = await _userManager.CreateAsync(user, viewModel.Password);
        if (result.Succeeded && viewModel is RegisterOrganisationViewModel)
        {
            var organisation = new Organization
            {
                Name = ((RegisterOrganisationViewModel)viewModel).OrganisationName
            };
            var org = _organisationRepository.AddOrganisation(organisation);
            user.Organization = org;
        }
        return result;
    }
}