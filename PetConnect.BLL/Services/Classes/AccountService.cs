using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetConnect.BLL.Common.AttachmentServices;
using PetConnect.BLL.Services.DTO.Account;
using PetConnect.BLL.Services.Interfaces;
using PetConnect.DAL.Data.Identity;
using PetConnect.DAL.Data.Models;
using PetConnect.DAL.UnitofWork;

namespace PetConnect.BLL.Services.Classes
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly SignInManager<ApplicationUser> signinManager;
        private readonly IAttachmentService attachmentService;

        public AccountService(IUnitOfWork _unitOfWork,
            UserManager<ApplicationUser> _userManager,
            RoleManager<ApplicationRole> _roleManager,
            SignInManager<ApplicationUser> _signinManager, IAttachmentService _attachmentService)
        {
            unitOfWork = _unitOfWork;
            userManager = _userManager;
            roleManager = _roleManager;
            signinManager = _signinManager;
            attachmentService = _attachmentService;
        }
        public async Task<List<string>> GetAllRolesAsync()
        {
            return await roleManager.Roles.Select(r => r.Name).ToListAsync();
        }

        public async Task<ApplicationUser> SignIn(SignInDTO model)
        {
            ApplicationUser? applicationUser = await userManager.FindByEmailAsync(model.Email);

            if(await userManager.CheckPasswordAsync(applicationUser, model.Password))
            {
                return applicationUser;
            }
            return null;
        }

        public async Task<bool> DoctorRegister(DoctorRegisterDTO model)
        {
            var ProfileImage = await attachmentService.UploadAsync(model.ImageUrl, Path.Combine("img", "doctors"));
            var CertificateImage = await attachmentService.UploadAsync(model.CertificateUrl, Path.Combine("img", "certificates"));

            var doctor = new Doctor
            {
                FName = model.FName,
                LName = model.LName,
                Email = model.Email,
                UserName = model.Email, 
                ImgUrl = $"/assets/img/doctors/{ProfileImage}",
                Gender = model.Gender,
                PricePerHour = model.PricePerHour,
                PetSpecialty = model.PetSpecialty,
                CertificateUrl = $"/assets/img/certificates/{CertificateImage}",
                Address = new Address
                {
                    Country = model.Country,
                    City = model.City,
                    Street = model.Street
                }
            };
            var result = await userManager.CreateAsync(doctor, model.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(doctor, "Doctor");
                return true;
            }
            return false;
        }

        public async Task<bool> CustomerRegister(CustomerRegisterDTO model)
        {
            var ProfileImage = await attachmentService.UploadAsync(model.ImageUrl, Path.Combine("img", "person"));

            var customer = new Customer
            {
                FName = model.FName,
                LName = model.LName,
                Email = model.Email,
                UserName = model.Email,
                ImgUrl = $"/assets/img/person/{ProfileImage}",
                Gender = model.Gender,
                Address = new Address
                {
                    Country = model.Country,
                    City = model.City,
                    Street = model.Street
                }
            };
            var result = await userManager.CreateAsync(customer, model.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(customer, "Customer");
                return true;
            }
            return false;
        }







    }
}

