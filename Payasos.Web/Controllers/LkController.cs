using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Payasos.Core.Services;

namespace Payasos.Controllers;

[Authorize]
public class LkController : Controller
{
    private readonly UserService _userService;

    public LkController(UserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    [Route("lk")]
    public IActionResult Organisation()
    {
        return View(_userService.GetUsers());
    }
}