using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetConnect.DAL.Data.Identity;
using PetConnect.DAL.Data;
using PetConnect.BLL.Services.Interfaces;
using PetConnect.BLL.Services.DTO.Account;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetConnect.DAL.Data.Enums;

namespace PetConnect.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(IAccountService _accountService,
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager)
        {
            accountService = _accountService;
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDTO model)
        {
            if (ModelState.IsValid)
            {
                bool isCorrectUser = await accountService.SignIn(model);
                if (isCorrectUser)
                    return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Username or Password is Incorrect !!!");
            return View("SignIn", model);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            List<string> Roles = await accountService.GetAllRolesAsync();
            ViewBag.Roles = Roles;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPost(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                switch (model.Role)
                {
                    case "Doctor":
                        return RedirectToAction("DoctorRegister");
                    case "Customer":
                        return RedirectToAction("CustomerRegister");
                    default:
                        return RedirectToAction("Register");
                }
            }
            return RedirectToAction("Register");
        }

        [HttpGet]
        public async Task<IActionResult> DoctorRegister(DoctorRegisterDTO model)
        {
            ViewBag.Specialties = Enum.GetValues(typeof(PetSpecialty))
            .Cast<PetSpecialty>()
            .Select(e => new SelectListItem
            {
                Value = e.ToString(),     
                Text = e.ToString()
            }).ToList();
            if (!ModelState.IsValid)
                return View(model);
            return View("DoctorRegisterPost");
        }

        [HttpPost]
        public async Task<IActionResult> DoctorRegisterPost(DoctorRegisterDTO model)
        {
            bool Succesed = await accountService.DoctorRegister(model);
            if (Succesed)
                return RedirectToAction("SignIn");
            return View("DoctorRegister", model);
        }































        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "Account");
        }
        public IActionResult CheckEmail(string email, [FromServices] AppDbContext context)
        {
            var ex = context.Users.Any(C => C.Email == email);
            if (ex)
                return Json(false);
            return Json(true);
        }
    }
}
