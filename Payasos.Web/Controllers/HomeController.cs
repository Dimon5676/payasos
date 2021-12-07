using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Payasos.Models;

namespace Payasos.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}