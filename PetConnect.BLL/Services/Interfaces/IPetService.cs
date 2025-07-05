using PetConnect.BLL.Services.DTO;
using PetConnect.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.BLL.Services.Interfaces
{
    public interface IPetService
    {


        void AddPet(AddedPetDto addedPet);
    }
}
