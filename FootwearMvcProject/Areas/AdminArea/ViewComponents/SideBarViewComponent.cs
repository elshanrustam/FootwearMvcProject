using Microsoft.AspNetCore.Mvc;

namespace FootwearMvcProject.Areas.AdminArea.ViewComponents
{
    [Area("AdminArea")]

    public class SideBarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
