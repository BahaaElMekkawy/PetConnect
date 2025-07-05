using Microsoft.AspNetCore.Mvc;
using PetConnect.BLL.Services.DTO;

namespace PetConnect.PL.Controllers
{
    public class PetController : Controller
    {

        // baseUrl/Pet/Index   >  Get All Pets
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddPet() { 
        
        return View();

        }
    }
}
