using Microsoft.AspNetCore.Mvc;
using PetConnect.BLL.Services.Interfaces;
using PetConnect.BLL.Services.Classes;
using PetConnect.DAL.Data.Models;
using PetConnect.BLL.Services.DTO.Doctor;
using PetConnect.DAL.Data.Enums;
using PetConnect.DAL.Data.Repositories.Interfaces;
using PetConnect.DAL.Data;
using PetConnect.DAL.Data.Repositories.Classes;

namespace PetConnect.PL.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorService doctorService;

        public DoctorsController(IDoctorService _doctorService)
        {
            doctorService = _doctorService;
        }
        public IActionResult Index(string? name, decimal? maxPrice, PetSpecialty? specialty)
        {
            var doctors = doctorService.GetAll();

            if (name != null)
            {
                doctors = doctors
                    .Where(d => d.FName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                                d.LName.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            if (maxPrice.HasValue)
            {
                doctors = doctors
                    .Where(d => d.PricePerHour <= maxPrice.Value);
            }

            if (specialty.HasValue)
            {
                doctors = doctors
                    .Where(d => d.PetSpecialty == specialty.Value.ToString());
            }

            var filteredList = doctors.ToList();

            if (!filteredList.Any())
            {
                ViewBag.Info = "No doctors found matching the criteria.";
            }

            return View(filteredList);
        }
        public IActionResult Profile(string id)
        {
            if (id == null)
                return NotFound();

            var doctorDTO = doctorService.GetByID(id);

            if (doctorDTO == null)
                return NotFound();

            return View(doctorDTO);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (id == null)
                return NotFound();

            var doctor = doctorService.GetByID(id);

            if (doctor == null)
                return NotFound();

            return View(doctor); // Pass DTO to Edit view
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DoctorDetailsDTO dto)
        {

            if (!ModelState.IsValid)
            {
                return View(dto); // Return with validation messages
            }

            try
            {
                doctorService.Update(dto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Update failed: {ex.Message}");
                return View(dto);
            }


        }
    }
}
