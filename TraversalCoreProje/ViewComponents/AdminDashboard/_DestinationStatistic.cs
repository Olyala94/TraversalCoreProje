using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.AdminDashboard
{
    [Area("Admin")]
    public class _DestinationStatistic : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
