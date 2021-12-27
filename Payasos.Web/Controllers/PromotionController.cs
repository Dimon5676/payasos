using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payasos.Core.Entities;
using Payasos.Core.Services;
using Payasos.Core.ViewModels;

namespace Payasos.Controllers;

public class PromotionController : Controller
{
    private readonly PromotionService _promotionService;
    private readonly OrganisationService _organisationService;

    public PromotionController(
        PromotionService promotionService,
        OrganisationService organisationService)
    {
        _promotionService = promotionService;
        _organisationService = organisationService;
    }
    
    [HttpGet]
    public IActionResult Ask()
    {
        var users = _promotionService.GetUserFromOrganisation(User);
        var org = _organisationService.GetUserOrganisation(User);
        return View(new PromotionRequestViewModel
        {
            Users = users,
            RoleWanted = org.Roles.First(),
            Roles = org.Roles,
            HardSkillsExpert = users.First(),
            SoftSkillsExpert = users.First(),
            EnglishExpert = users.First(),
            InterviewDate = DateTime.Now
        });
    }

    [HttpPost]
    public IActionResult AddRequest(PromotionRequestViewModel viewModel)
    {
        var users = _promotionService.GetUserFromOrganisation(User);
        var org = _organisationService.GetUserOrganisation(User);
        if (!ModelState.IsValid) return View("Ask", new PromotionRequestViewModel
        {
            Users = users,
            RoleWanted = org.Roles.First(),
            Roles = org.Roles,
            HardSkillsExpert = users.First(),
            SoftSkillsExpert = users.First(),
            EnglishExpert = users.First(),
            InterviewDate = DateTime.Now
        });
        
        _promotionService.AddRequest(viewModel, User);
        return RedirectToAction("Organisation", "Lk");
    }
}