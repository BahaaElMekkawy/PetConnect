using Microsoft.AspNetCore.Mvc;

namespace PetConnect.PL.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
