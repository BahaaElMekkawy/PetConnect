using PetConnect.BLL.Services.DTO.Doctor;
using PetConnect.BLL.Services.DTO.PetDto;

namespace PetConnect.PL.ViewModels
{
    public class EntitiesInHomeView
    {
        public List<DoctorDetailsDTO> DoctorDetailsDTOs { get; set; } = new List<DoctorDetailsDTO>();
        public List<PetDataDto> PetDataDtos { get; set; } = new List<PetDataDto>();
    }
}
