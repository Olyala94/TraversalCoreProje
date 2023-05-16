using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProje.CQRS.Result.DestinationResults;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler _getAlldestinationQueryHandler;
        private readonly GetDestinationByIDQueryHandler _getdestinationByIDQueryHandler;

        public DestinationCQRSController(GetAllDestinationQueryHandler getAlldestinationQueryHandler, GetDestinationByIDQueryHandler getdestinationByIDQueryHandler)
        {
            _getAlldestinationQueryHandler = getAlldestinationQueryHandler;
            _getdestinationByIDQueryHandler = getdestinationByIDQueryHandler;
        }

        public IActionResult Index()
        {
            var values = _getAlldestinationQueryHandler.Handle()
;            return View(values);
        }

        public IActionResult GetDestination(int id)
        {
            var values = _getdestinationByIDQueryHandler.Handle(new GetDestinationByIDQuery(id));
            return View(values);    
        }
    }
}
