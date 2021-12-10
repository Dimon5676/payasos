using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Payasos.Core.Services;
using Payasos.Core.ViewModels;
using Payasos.Models;

namespace Payasos.Controllers;

public class UserController : Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
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