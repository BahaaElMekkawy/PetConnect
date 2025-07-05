using Microsoft.AspNetCore.Mvc;
using PetConnect.BLL.Services.DTO.PetCategoryDto;
using PetConnect.BLL.Services.Interfaces;

namespace PetConnect.PL.Controllers
{
    public class PetCategoryController : Controller
    {
        private readonly IPetCategoryService _petCategoryService;

        public PetCategoryController(IPetCategoryService petCategoryService)
        {
            _petCategoryService = petCategoryService;
        }
        #region GetAll
        public IActionResult Index()
        {
            var Model = _petCategoryService.GetAllCategories(false);
            return View(Model);
        }
        #endregion

        #region Add
        [HttpGet]
        public IActionResult Add()
        {

            return View();

        }

        [HttpPost]
        public IActionResult Add(AddedPetCategoryDTO AddedPetCategoryDTO)
        {
            if (ModelState.IsValid && _petCategoryService.AddPetCategory(AddedPetCategoryDTO) > 0)
            {

                return RedirectToAction(nameof(Index));
            }

            return View();

        }
        #endregion



        [HttpGet]
        public IActionResult EditDelete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var model = _petCategoryService.GetPetCategoryById(id.Value);
            if (model is null)
                return NotFound();

            return View(model);

        }

        [HttpPost]
        public IActionResult Edit(UPetCategoryDto UPetCategoryDto)
        {
            if (ModelState.IsValid && _petCategoryService.UpdatePetCategory(UPetCategoryDto) > 0)
            {

                return RedirectToAction(nameof(Index));
            }

            return View();

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            if (ModelState.IsValid && _petCategoryService.DeletePetCategory(id) > 0)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));

        }
    }
}
