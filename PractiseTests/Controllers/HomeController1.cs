using Microsoft.AspNetCore.Mvc;

namespace PractiseTests.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
