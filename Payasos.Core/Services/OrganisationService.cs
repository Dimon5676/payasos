using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Payasos.Core.Entities;
using Payasos.Core.Repositories;
using Payasos.Core.ViewModels;

namespace Payasos.Core.Services;

public class OrganisationService
{
    private readonly IOrganisationRepository _organisationRepository;
    private readonly UserManager<AppUser> _userManager;

    public OrganisationService(
        IOrganisationRepository organisationRepository,
        UserManager<AppUser> userManager)
    {
        _organisationRepository = organisationRepository;
        _userManager = userManager;
    }

    public Organization GetUserOrganisation(ClaimsPrincipal claims)
    {
        return _userManager.Users
            .Include(e => e.Organization)
            .ThenInclude(e => e.Roles)
            .FirstOrDefault(e => e.UserName == claims.Identity.Name)
            ?.Organization;
    }

    public void ChangeUserOrganisationInfo(ClaimsPrincipal claims, OrganisationSettingsViewModel viewModel)
    {
        var org = GetUserOrganisation(claims);
        org.Name = viewModel.OrgName;
        org.Code = viewModel.InviteCode;
        org.DefaultRoleId = viewModel.SelectedRole.Id;
        _organisationRepository.SaveChanges();
    }

    public void AddRole(ClaimsPrincipal claims, string role)
    {
        var org = GetUserOrganisation(claims);
        var newRole = new Role
        {
            Name = role
        };
        
        if (org.Roles == null) 
        {
            org.Roles = new[] { newRole };
        }
        else
        {
            if (org.Roles.FirstOrDefault(e => e.Name == role) != null) throw new Exception("Роль уже существует");
            org.Roles.Add(newRole);
        }
        
        _organisationRepository.SaveChanges();
    }
}