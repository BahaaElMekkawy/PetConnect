using Microsoft.AspNetCore.Mvc;
using PetConnect.BLL.Services.Classes;
using PetConnect.BLL.Services.DTO.PetBreadDto;
using PetConnect.BLL.Services.Interfaces;
using PetConnect.PL.ViewModels;

namespace PetConnect.PL.Controllers
{
    public class PetBreadController : Controller
    {
        private readonly IPetBreadService _PetBreadService;
        private readonly IPetCategoryService _PetCategoryService;

        public PetBreadController(IPetBreadService petBreadService, IPetCategoryService petCategoryService)
        {
            _PetBreadService = petBreadService;
            _PetCategoryService = petCategoryService;
        }
        public IActionResult Index()
        {
          var Model=  _PetBreadService.GetAllBreads();
            return View(Model);
        }

        [HttpGet]
        public IActionResult Add() { 
        var Categories = _PetCategoryService.GetAllCategories().GPetCategoryDto;

            var viewModel = new AddPetBreadViewModel();
            viewModel.GPetCategoryDtos = Categories;
        return View(viewModel);
        }
        [HttpPost]
        public IActionResult Add(AddPetBreadViewModel AddPetBreadViewModel)
        {
            if (ModelState.IsValid && _PetBreadService.AddPetBread(AddPetBreadViewModel.PetBreadDto) > 0) {
                return RedirectToAction(nameof(Index));
            
            }

            AddPetBreadViewModel.GPetCategoryDtos = _PetCategoryService.GetAllCategories().GPetCategoryDto;
            return View(AddPetBreadViewModel);
        }

        public IActionResult EditDelete(int? id) {
            if (id is null)
                return BadRequest();
            var Model = _PetBreadService.GetBreadById(id.Value);
            if(Model is null)
                return NotFound();

            var viewModel = new UpdatePetBreadViewModel();
            viewModel.GPetCategoryDtos = _PetCategoryService.GetAllCategories().GPetCategoryDto;
            viewModel.UPetBreadDto = Model;

            return View(viewModel);
        }


        public IActionResult Edit(UpdatePetBreadViewModel UpdatePetBreadViewModel) {

           
            if (ModelState.IsValid && _PetBreadService.UpdatePetBread(UpdatePetBreadViewModel.UPetBreadDto) >0) {
                return RedirectToAction(nameof(Index));
            }

            UpdatePetBreadViewModel.GPetCategoryDtos = _PetCategoryService.GetAllCategories().GPetCategoryDto;
            return View(UpdatePetBreadViewModel);
        }
        public IActionResult Delete(int? id) {
            if (id is null)
                return BadRequest();
           if (_PetBreadService.DeletePetBread(id.Value) > 0)
                return RedirectToAction(nameof(Index));

            return View();
        }

    }
}
