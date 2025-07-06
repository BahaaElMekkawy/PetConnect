using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetConnect.BLL.Services.DTO.Account;

namespace PetConnect.BLL.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<bool> SignIn(SignInDTO model);
        public Task<List<string>> GetAllRolesAsync();
        public Task<bool> DoctorRegister(DoctorRegisterDTO model);


    }
}
