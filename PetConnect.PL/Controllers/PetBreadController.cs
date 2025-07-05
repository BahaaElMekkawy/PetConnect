using Microsoft.AspNetCore.Mvc;
using PetConnect.BLL.Services.Classes;
using PetConnect.BLL.Services.DTO.PetBreadDto;
using PetConnect.BLL.Services.Interfaces;

namespace PetConnect.PL.Controllers
{
    public class PetBreadController : Controller
    {
        private readonly IPetBreadService _PetBreadService;

        public PetBreadController(IPetBreadService petBreadService)
        {
            _PetBreadService = petBreadService;
        }
        public IActionResult Index()
        {
          var Model=  _PetBreadService.GetAllBreads();
            return View(Model);
        }

        [HttpGet]
        public IActionResult Add() { 
        
        
        return View();
        }
        [HttpPost]
        public IActionResult Add(AddedPetBreadDto addedPetBreadDto)
        {
            if (ModelState.IsValid && _PetBreadService.AddPetBread(addedPetBreadDto) > 0) {
                return RedirectToAction(nameof(Index));
            
            }
         
            return View(addedPetBreadDto);
        }

        public IActionResult EditDelete(int? id) {
            if (id is null)
                return BadRequest();
            var Model = _PetBreadService.GetBreadById(id.Value);
            if(Model is null)
                return NotFound();

            return View(Model);
        }


        public IActionResult Edit(UPetBreadDto UPetBread) {

            if (ModelState.IsValid && _PetBreadService.UpdatePetBread(UPetBread)>0) {
                return RedirectToAction(nameof(Index));
            }
            return View(UPetBread);
        }
        public IActionResult Delete(int? id) {
            if (id is null)
                return BadRequest();
           if (_PetBreadService.DeletePetBread(id.Value)>0)
                return RedirectToAction(nameof(Index));

            return View();
        }

    }
}
