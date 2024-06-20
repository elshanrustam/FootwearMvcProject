using Microsoft.AspNetCore.Mvc;

namespace FootwearMvcProject.Controllers
{
    public class MenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
