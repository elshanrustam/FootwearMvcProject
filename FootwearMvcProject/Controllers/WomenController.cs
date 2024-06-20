using Microsoft.AspNetCore.Mvc;

namespace FootwearMvcProject.Controllers
{
    public class WomenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
