using Microsoft.AspNetCore.Mvc.Rendering;
using PetConnect.BLL.Services.DTO.PetBreadDto;
using PetConnect.BLL.Services.DTO.PetCategoryDto;

namespace PetConnect.PL.ViewModels
{
    public class AddPetBreadViewModel
    {
        public AddedPetBreadDto PetBreadDto { get; set; } = new();

        public List<GPetCategoryDto> GPetCategoryDtos { get; set; } = new List<GPetCategoryDto>();
    }
}
