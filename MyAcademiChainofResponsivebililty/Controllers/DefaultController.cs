using Microsoft.AspNetCore.Mvc;
using MyAcademiChainofResponsivebililty.ChainOfResponsivibility;
using MyAcademiChainofResponsivebililty.Models;

namespace MyAcademiChainofResponsivebililty.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Clerk _clerk;
        private readonly AssistantManager _assistantManager;
        private readonly Manager _manager;
        private readonly RegionalManager _regionalManager;

        public DefaultController(Clerk clerk, AssistantManager assistantManager, Manager manager, RegionalManager regionalManager)
        {
            _clerk = clerk;
            _assistantManager = assistantManager;
            _manager = manager;
            _regionalManager = regionalManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CusterProcessViewModel model)
        {
            _clerk.SetNextApprover(_assistantManager);
            _assistantManager.SetNextApprover(_manager);
            _manager.SetNextApprover(_regionalManager);
            
            _clerk.Process(model);

            if (model!=null)
            {
                ViewBag.description = "para çekme başarılı";
            }

            return NoContent();
        }
    }
}
