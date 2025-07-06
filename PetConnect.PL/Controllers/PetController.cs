using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetConnect.BLL.Services.DTO;
using PetConnect.BLL.Services.DTO.PetDto;
using PetConnect.BLL.Services.Interfaces;

namespace PetConnect.PL.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetService _petService;
        private readonly IPetCategoryService _petCategoryService;

        public PetController(IPetService petService, IPetCategoryService petCategoryService)
        {
            _petService = petService;
            _petCategoryService = petCategoryService;
        }

        // baseUrl/Pet/Index   >  Get All Pets
        public IActionResult Index()
        {
            var model = _petService.GetAllPets(4);
            return View(model);
        }
        public IActionResult PetDetails(int? id)
        {
            if (id == null)
                return BadRequest();
           var model =  _petService.GetPet(id.Value);
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddPet()
        {
            ViewBag.Categories = _petCategoryService.GetAllCategories();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPet(AddedPetDto AddPet)
        {
            if (ModelState.IsValid)
            {
               await _petService.AddPet(AddPet);
                return RedirectToAction("Index");
            }
            return View("AddPet",AddPet);
        }
        //[HttpGet]
        //public IActionResult UpdatePet(int id)
        //{

        //}
        //public IActionResult UpdatePet()
        //{
        //}
        //public IActionResult DeletePet(int id)
        //{

        //}
        //public IActionResult DeletePet()
    }
}
