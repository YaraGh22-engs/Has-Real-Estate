using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Has_Real_Estate.Controllers
{
    
    public class AdminOperationsController : Controller
    {
        private readonly IAdminOperationsRepo _adminrepo;
        public AdminOperationsController(IAdminOperationsRepo adminrepo)
        {
            _adminrepo = adminrepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllEstates() 
        { 
           var es= _adminrepo.GetAllEstates();
            return View(es);
        }

        public async Task<IActionResult> ToggleApprovementStatus(int estateId) 
        {
            await _adminrepo.ToggleApprovementStatus(estateId);
            return RedirectToAction("GetAllEstates");
        
        }

    }
}
