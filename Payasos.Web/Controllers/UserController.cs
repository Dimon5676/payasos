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
        return View("RegisterUser", new RegisterUserViewModel { Code = code});
    }
    
    [HttpPost]
    public async Task<IActionResult> RegisterUserPost(RegisterUserViewModel viewModel)
    {
        if (!ModelState.IsValid) return View("RegisterUser");
            try
        {
            return Ok(await _userService.RegisterUser(viewModel));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Problem(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> RegisterOrganisationPost(RegisterOrganisationViewModel viewModel)
    {
        if (!ModelState.IsValid) return View("RegisterOrganisation");
        try
        {
            return Ok(await _userService.RegisterOrganisation(viewModel));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Problem(e.Message);
        }
    }
}