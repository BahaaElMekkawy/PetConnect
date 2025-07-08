using Microsoft.AspNetCore.Mvc;
using PetConnect.BLL.Services.DTOs.Customer;
using PetConnect.BLL.Services.Interfaces;
using PetConnect.DAL.UnitofWork;

namespace PetConnect.PL.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // Customer Profile
        public IActionResult Index()
        {
            return View();
        }


        // can get the userid from cookie and send it with the petid in a model  / or can we send the petid alone and get the userid here from 'User' as cookie
        [HttpGet]
        public IActionResult Adoption(CusRequestAdoptionDto adoptionDto) {
            //  var UserId = User.Identity.ID;
            _customerService.RequestAdoption(adoptionDto);
            return View();


        }
        // we get the user id from the cookie
        public IActionResult GetAdoptionDataForCustomer() {
        
            _customerService.GetCustomerReqAdoptionsData("UserId");
            return View();
        
        }

    }
}
