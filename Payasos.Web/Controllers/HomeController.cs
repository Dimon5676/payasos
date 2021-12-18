using Microsoft.AspNetCore.Mvc;

namespace Payasos.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [Route("license")]
    public IActionResult License()
    {
        return View();
    }
}