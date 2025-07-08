using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PetConnect.BLL.Services.Classes;
using PetConnect.BLL.Services.DTO.Doctor;
using PetConnect.BLL.Services.DTO.PetDto;
using PetConnect.BLL.Services.Interfaces;
using PetConnect.PL.Models;
using PetConnect.PL.ViewModels;

namespace PetConnect.PL.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    IDoctorService doctorService;
    private readonly IPetService petService;

    public HomeController(ILogger<HomeController> logger, IDoctorService _doctorService,IPetService _petService)
    {
        _logger = logger;
        doctorService = _doctorService;
        petService = _petService;
    }

    public IActionResult Index()
    {
     List<DoctorDetailsDTO> TopDoctors =  doctorService.GetAll().Take(4).ToList();
     List<PetDataDto> TopPets = petService.GetAllPetsByCountForAdoption(4).ToList();
        EntitiesInHomeView entitiesInHome = new EntitiesInHomeView() { PetDataDtos=TopPets,DoctorDetailsDTOs=TopDoctors};
        return View(entitiesInHome);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
