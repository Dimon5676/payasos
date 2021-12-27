using Microsoft.AspNetCore.Mvc;

namespace Payasos.Controllers;

public class PromotionController : Controller
{
    public IActionResult Ask()
    {
        return View();
    }
}