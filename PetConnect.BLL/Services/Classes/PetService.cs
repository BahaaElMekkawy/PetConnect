using PetConnect.BLL.Services.DTO.PetDto;
using PetConnect.BLL.Services.Interfaces;
using PetConnect.DAL.Data.Models;
using PetConnect.DAL.UnitofWork;
using PetConnect.BLL.Common.AttachmentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PetConnect.DAL.Data.Repositories.Interfaces;

namespace PetConnect.BLL.Services.Classes
{
    public class PetService : IPetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAttachmentService _attachmentService;
        public PetService(IUnitOfWork unitOfWork , IAttachmentService attachmentService)
        {
            _unitOfWork = unitOfWork;
            _attachmentService = attachmentService;


        }

        public IAttachmentService AttachmentService { get; }

        public async Task <int> AddPet(AddedPetDto addedPet )
        {
            var Image = await _attachmentService.UploadAsync(addedPet.form, "PetImages");
            var PetData = new Pet() {Name = addedPet.Name , ImgUrl = Image
                , BreedId = addedPet.BreedId , IsApproved= false , Ownership =addedPet.Ownership ,
                Status = addedPet.Status };
   
            _unitOfWork.PetRepository.Add(PetData);
           return _unitOfWork.SaveChanges();
        }

       

        public void DeletePet(int id)
        {
            
        }

        public IEnumerable<PetDataDto> GetAllPets(int? count)
        {
            List<PetDataDto> petDatas = new List<PetDataDto>();
            IEnumerable<Pet> PetList;
            if (count is null)
                PetList = _unitOfWork.PetRepository.GetAll();
            else
                PetList = _unitOfWork.PetRepository.GetAll().Take(count.Value);
            foreach (var Pet in PetList)
            {
                petDatas.Add(new PetDataDto()
                {
                    Name = Pet.Name,
                    ImgUrl = Pet.ImgUrl,
                    Status = Pet.Status,
                    Id = Pet.Id,
                });
        }
            return petDatas;
        }

        public PetDetailsDto? GetPet(int id)
        {
           
            var pet =  _unitOfWork.PetRepository.GetByID(id);
            var bread =   _unitOfWork.PetBreedRepository.GetByID(pet.BreedId);
            var Category =   _unitOfWork.PetCategoryRepository.GetByID(bread.CategoryId);
            PetDetailsDto Pet = new PetDetailsDto() {Name = pet.Name , IsApproved = pet.IsApproved ,BreadName =bread.Name  ,
            ImgUrl = pet.ImgUrl , Ownership = pet.Ownership , Status = pet.Status , CategoryName = Category.Name};
            return Pet;
        }

        public void UpdatePet(UpdatedPetDto UpdatedPet)
        {
            throw new NotImplementedException();
        }

    }
}
