﻿using Microsoft.AspNetCore.Mvc;

namespace PetConnect.PL.Controllers
{
    public class DoctorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
