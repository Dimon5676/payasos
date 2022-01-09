using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payasos.Core.Entities;
using Payasos.Core.Services;
using Payasos.Core.ViewModels;

namespace Payasos.Controllers;

[Authorize]
public class PromotionController : Controller
{
    private readonly PromotionService _promotionService;
    private readonly OrganisationService _organisationService;
    private readonly UserManager<AppUser> _userManager;

    public PromotionController(
        PromotionService promotionService,
        OrganisationService organisationService,
        UserManager<AppUser> userManager)
    {
        _promotionService = promotionService;
        _organisationService = organisationService;
        _userManager = userManager;
    }
    
    [HttpGet]
    public IActionResult Ask()
    {
        var user = _userManager.Users
            .Include(x => x.Role)
            .FirstOrDefault(e => e.UserName == User.Identity.Name);
        var users = _promotionService.GetUserFromOrganisation(User).Where(e => e != user).ToList();
        if (users.Count < 2) return RedirectToAction("Organisation", "Lk");
        var org = _organisationService.GetUserOrganisation(User);
        var roles = org.Roles.Where(e => e != user.Role).ToList();
        return View(new PromotionRequestViewModel
        {
            Users = users,
            RoleWanted = roles.First(),
            Roles = roles,
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
        if (!ModelState.IsValid || users.Count < 2) return View("Ask", new PromotionRequestViewModel
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

    [HttpGet]
    public IActionResult Requests()
    {
        return View( _promotionService.GetRequests(User));
    }

    [HttpGet]
    public IActionResult SeeRequest(int id)
    {
        var request = _promotionService.GetRequestById(id);
        if (request == null) return RedirectToAction("Organisation", "Lk");
        return View("Request",request);
    }

    [HttpPost]
    public IActionResult AddMark(bool passed, int requestId)
    {
        var request = _promotionService.GetRequestById(requestId);
        if (request == null) return RedirectToAction("Organisation", "Lk");
        _promotionService.AddMark(User, passed, requestId);
        return RedirectToAction("SeeRequest", new {id = requestId});
    }
    
    [HttpPost]
    public IActionResult CloseRequest(int requestId)
    {
        var request = _promotionService.GetRequestById(requestId);
        if (request == null) return RedirectToAction("Organisation", "Lk");
        _promotionService.CloseRequest(User, requestId);
        return RedirectToAction("Requests");
    }
}