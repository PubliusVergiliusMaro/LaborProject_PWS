using Microsoft.AspNetCore.Mvc;

namespace LaborProject_PWS.Web.Views.Shared.Components.Navbar
{
    public class NavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
