using Microsoft.AspNetCore.Mvc;

namespace FootwearMvcProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
