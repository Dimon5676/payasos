using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Payasos.Core.Services;
using Payasos.Core.ViewModels;
using Payasos.Infrastructure.Repositories;

namespace Payasos.Controllers;

[Authorize]
public class LkController : Controller
{
    private readonly UserService _userService;
    private readonly OrganisationService _organisationService;

    public LkController(
        UserService userService,
        OrganisationService organisationService)
    {
        _userService = userService;
        _organisationService = organisationService;
    }
    
    [HttpGet]
    [Route("lk")]
    public ViewResult Organisation()
    {
        var org = _organisationService.GetUserOrganisation(User);
        return View(new LkViewModel
        {
            Users = _userService.GetUsers(User),
            OrgName = org.Name,
            InviteCode = org.Code
        });
    }
}