using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.DAL.Data.Models
{
    public class ShelterLocations
    {
        public int ShelterId { get; set; }
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string Country { get; set; } = null!;

    }
}
