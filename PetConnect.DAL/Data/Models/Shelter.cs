using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PetConnect.DAL.Data.Models
{
    public class Shelter
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int OwnerId { get; set; }

        public ICollection<ShelterAddedPets> ShelterAddedPets { get; set; } = new HashSet<ShelterAddedPets>();
        public ICollection<ShelterPetAdoptions> ShelterPetAdoptions { get; set; } = new HashSet<ShelterPetAdoptions>();

    }
}
