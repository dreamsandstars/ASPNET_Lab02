using Microsoft.AspNetCore.Mvc;

namespace BookstoreLab02.Mvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}
