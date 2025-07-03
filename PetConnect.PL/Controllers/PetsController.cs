using Microsoft.AspNetCore.Mvc;

namespace PetConnect.PL.Controllers
{
    public class PetsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
