
using Microsoft.AspNetCore.Identity;

using PetConnect.DAL.Data.Enums;

namespace PetConnect.DAL.Data.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;
        public bool IsApproved { get; set; } 
        public Gender Gender{ get; set; } 
        public string City{ get; set; } = null!;
        public string Country{ get; set; } = null!;
        public string Street{ get; set; } = null!;
        public string? ImgUrl{ get; set; } = null!;
    }
}
