using Microsoft.AspNetCore.Mvc;

namespace FootwearMvcProject.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
