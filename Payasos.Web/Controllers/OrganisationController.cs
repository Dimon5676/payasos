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
    
    [HttpGet]
    public IActionResult Settings()
    {
        var org = _organisationService.GetUserOrganisation(User);
        return View(new OrganisationSettingsViewModel
        {
            OrgName = org.Name,
            InviteCode = org.Code,
            Roles = org.Roles,
            SelectedRole = org.Roles.FirstOrDefault(e => e.Id == org.DefaultRoleId)
        });
    }

    [HttpPost]
    public IActionResult ChangeInfo(OrganisationSettingsViewModel viewModel)
    {
        var org = _organisationService.GetUserOrganisation(User);
        if (!ModelState.IsValid) return View("Settings", new OrganisationSettingsViewModel
        {
            OrgName = org.Name,
            InviteCode = org.Code,
            Roles = org.Roles,
            SelectedRole = org.Roles.FirstOrDefault(e => e.Id == org.DefaultRoleId)
        });
        _organisationService.ChangeUserOrganisationInfo(User, viewModel);
        return RedirectToAction("Organisation", "Lk");
    }

    [HttpPost]
    public IActionResult AddRole(string role)
    {
        var org = _organisationService.GetUserOrganisation(User);
        if (role == null || role.Length > 20 || role.Length < 3)
        {
            ModelState.AddModelError("", "Название роли должно быть в пределах от 3 до 20 символов");
            ViewBag.Roles = org.Roles;
            return View("Settings", new OrganisationSettingsViewModel
            {
                OrgName = org.Name,
                InviteCode = org.Code,
                Roles = org.Roles,
                SelectedRole = org.Roles.FirstOrDefault(e => e.Id == org.DefaultRoleId)
            });
        }

        try
        {
            _organisationService.AddRole(User, role);
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
            ViewBag.Roles = org.Roles;
            return View("Settings", new OrganisationSettingsViewModel
            {
                OrgName = org.Name,
                InviteCode = org.Code,
                Roles = org.Roles,
                SelectedRole = org.Roles.FirstOrDefault(e => e.Id == org.DefaultRoleId)
            });
        }
        return RedirectToAction("Settings");
    }
}