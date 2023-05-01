using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.AdminDashboard
{
    [Area("Admin")]

    public class _Cards2Statistics : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
