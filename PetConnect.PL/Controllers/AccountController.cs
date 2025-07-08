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
        private readonly RoleManager<ApplicationRole> roleManager;

        public AccountController(IAccountService _accountService,
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,RoleManager<ApplicationRole> _roleManager)
        {
            accountService = _accountService;
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
 




        [HttpPost]
    public async Task<IActionResult> SignIn(SignInDTO model)
    {
        if (!ModelState.IsValid)
        {
            return View("SignIn", model);
        }

            var user = await accountService.SignIn(model); // Return ApplicationUser or null

            if (user != null)
        {
            await signInManager.SignInAsync(user, model.RememberMe);
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
        public IActionResult DoctorRegister()
        {
            

            return View();
        }

        [HttpGet]
        public IActionResult CustomerRegister()
        {


            return View();
        }





        [HttpPost]
    public async Task<IActionResult> DoctorRegisterPost(DoctorRegisterDTO model)
    {


        if (!ModelState.IsValid)
        {
            return View("DoctorRegister", model); // Show form again with errors
        }

        bool succeeded = await accountService.DoctorRegister(model);

        if (succeeded)
        {
            return RedirectToAction("SignIn");
        }

        ModelState.AddModelError("", "Registration failed. Please try again.");
        return View("DoctorRegister", model);
    }

        public async Task<IActionResult> CustomerRegisterPost(CustomerRegisterDTO model)
        {


            if (!ModelState.IsValid)
            {
                return View("CustomerRegister", model); // Show form again with errors
            }

            bool succeeded = await accountService.CustomerRegister(model);

            if (succeeded)
            {
                return RedirectToAction("SignIn");
            }

            ModelState.AddModelError("", "Registration failed. Please try again.");
            return View("CustomerRegister", model);
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
