using Microsoft.AspNetCore.Mvc;
using PetConnect.BLL.Common.AttachmentServices;
using PetConnect.BLL.Services.Classes;
using PetConnect.BLL.Services.DTOs.Customer;
using PetConnect.BLL.Services.Interfaces;
using PetConnect.DAL.Data.Models;
using PetConnect.DAL.UnitofWork;
using System.Security.Claims;

namespace PetConnect.PL.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IAttachmentService attachmentService;

        public CustomerController(ICustomerService customerService, IAttachmentService attachmentService)
        {
            _customerService = customerService;
            this.attachmentService = attachmentService;
        }


        // all customers
        public IActionResult Index(string? name, string? city)
        {
            var customers = _customerService.GetAllCustomers();

            if (!string.IsNullOrEmpty(name))
            {
                customers = customers
                    .Where(c => c.FName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                                c.LName.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(city))
            {
                customers = customers
                    .Where(c => c.City.Contains(city, StringComparison.OrdinalIgnoreCase));
            }

            var filtered = customers.ToList();

            if (!filtered.Any())
                ViewBag.Info = "No customers found.";

            return View(filtered);
        }

        // Customer Profile
        public IActionResult Profile()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) {return  RedirectToAction("index"); }
            CustomerProfileDTO c = _customerService.GetProfile(userId);
            return View(c);
        }
        public IActionResult Details(string id)
        {
           
            CustomerProfileDTO c = _customerService.GetProfile(id);
            return View(c);
        }
        //delete customer
        public IActionResult Delete(string id)
        {

            _customerService.Delete(id);
            return RedirectToAction("Index");

        }
        //update
        [HttpGet]
        public IActionResult Edit(string id)
        {

          
                if (id == null)
                    return NotFound();

                var customer = _customerService.GetProfile(id);

            if (customer == null)
                    return NotFound();

                return View(customer); // Pass DTO to Edit view
            

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerProfileDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var existingCustomer = _customerService.GetProfile(model.Id);

                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    var fileName = await attachmentService.UploadAsync(model.ImageFile, Path.Combine("img", "person"));

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        model.ImgUrl = $"/assets/img/person/{fileName}";
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "Invalid file. Please upload a PNG, JPG, JPEG or PDF under 2MB.");
                        return View(model);
                    }
                }
                else
                {
                    if (existingCustomer != null)
                        model.ImgUrl = existingCustomer.ImgUrl;
                }

                await _customerService.UpdateProfile(model);

                return RedirectToAction("Profile", new { id = model.Id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Update failed: {ex.Message}");
                return View(model);
            }
        }

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
