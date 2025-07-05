using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.BLL.Services.DTO.Doctor
{
  public class DoctorDetailsDTO
    {
        [Required]
        public string Id { get; set; } = null!;

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(20, ErrorMessage = "First name cannot exceed 20 characters.")]
        public string FName { get; set; } = null!;

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(20, ErrorMessage = "Last name cannot exceed 20 characters.")]
        public string LName { get; set; } = null!;

        [Display(Name = "Profile Image URL")]
        [Required(ErrorMessage = "Image URL is required.")]
        [StringLength(100, ErrorMessage = "Image URL cannot exceed 100 characters.")]
        public string ImgUrl { get; set; } = null!;

        [Display(Name = "Specialty")]
        [Required(ErrorMessage = "Specialty is required.")]
        public string PetSpecialty { get; set; } = null!;

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; } = null!;

        [Display(Name = "Price Per Hour (EGP)")]
        [Range(1, 10000, ErrorMessage = "Price must be between 1 and 10,000 EGP.")]
        public decimal PricePerHour { get; set; }

        [Display(Name = "Certificate URL")]
        [Required(ErrorMessage = "Certificate URL is required.")]
        public string CertificateUrl { get; set; } = null!;

        [Display(Name = "Street Address")]
        [Required(ErrorMessage = "Street address is required.")]
        [StringLength(20, ErrorMessage = "Street name can't be longer than 20 characters.")]
        public string Street { get; set; } = null!;

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City name can't be longer than 20 characters.")]
        public string City { get; set; } = null!;
    }
}
