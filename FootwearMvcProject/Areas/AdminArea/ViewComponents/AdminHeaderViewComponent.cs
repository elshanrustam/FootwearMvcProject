using Microsoft.AspNetCore.Mvc;

namespace FootwearMvcProject.Areas.AdminArea.ViewComponents
{
    public class AdminHeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
