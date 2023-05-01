using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _Feature1 : ViewComponent
    {
       Feature1Manager feature1Manager = new Feature1Manager(new EfFeature1Dal());

        public IViewComponentResult Invoke()
        {
            //var values = featureManager.TGetList();
           /// ViewBag.image1 = feature1Manager.
            return View();
        }
    }
}
