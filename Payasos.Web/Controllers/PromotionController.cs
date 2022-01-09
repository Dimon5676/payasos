using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Payasos.Core.Services;
using Payasos.Core.ViewModels;

namespace Payasos.Controllers;

[Authorize]
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