using PetConnect.BLL.Services.DTO.PetBreadDto;
using PetConnect.BLL.Services.DTO.PetCategoryDto;

namespace PetConnect.PL.ViewModels
{
    public class UpdatePetBreadViewModel
    {
        public UPetBreadDto UPetBreadDto { get; set; } = new();
        public List<GPetCategoryDto> GPetCategoryDtos { get; set; } = new List<GPetCategoryDto>();
    }
}
