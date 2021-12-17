using Microsoft.AspNetCore.Mvc;
using Payasos.Core.Services;
using Payasos.Core.ViewModels;

namespace Payasos.Controllers;

public class UserController : Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    [Route("register/organisation")]
    public IActionResult RegisterOrganisation()
    {
        return View();
    }
    
    [HttpGet]
    [Route("register/user/{code?}")]
    public IActionResult RegisterUser(string code)
    {
        return View("RegisterUser");
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel viewModel)
    {
        var result = await _userService.Register(viewModel);
        if (result.Succeeded)
        {
            return Ok("User created");
        }

        return Problem(result.Errors.ToString());
    }
}