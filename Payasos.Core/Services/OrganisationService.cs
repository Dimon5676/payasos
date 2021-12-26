using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Payasos.Core.Entities;
using Payasos.Core.Repositories;

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
            .FirstOrDefault(e => e.UserName == claims.Identity.Name)
            ?.Organization;
    }
}