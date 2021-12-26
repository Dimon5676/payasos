using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Payasos.Core.Entities;
using Payasos.Core.Services;
using Payasos.Core.ViewModels;

namespace Payasos.Controllers;

[Authorize]
public class OrganisationController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly OrganisationService _organisationService;

    public OrganisationController(
        UserManager<AppUser> userManager, 
        OrganisationService organisationService)
    {
        _userManager = userManager;
        _organisationService = organisationService;
    }
    
    public IActionResult Settings()
    {
        var org = _organisationService.GetUserOrganisation(User);   
        return View(new OrganisationSettingsViewModel
        {
            OrgName = org.Name,
            InviteCode = org.Code,
            Roles = org.Roles?.Select(e => e.Name)
        });
    }
}