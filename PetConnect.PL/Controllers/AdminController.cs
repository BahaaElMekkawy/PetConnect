using Microsoft.AspNetCore.Mvc;
using PetConnect.BLL.Services.Interfaces;

namespace PetConnect.PL.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService _adminService)
        {
            adminService = _adminService;
        }
        public IActionResult Index()
        {
            var dashboard = adminService.GetPendingDoctorsAndPets();
            return View(dashboard);
        }

        public IActionResult ApproveDoctor(string id) 
        {
            adminService.ApproveDoctor(id);
            var dashboard = adminService.GetPendingDoctorsAndPets();

            return View("Index" , dashboard);
        }
        public IActionResult ApprovePet(int id)
        {
            adminService.ApprovePet(id);
            var dashboard = adminService.GetPendingDoctorsAndPets();

            return View("Index", dashboard);
        }
    }
}
