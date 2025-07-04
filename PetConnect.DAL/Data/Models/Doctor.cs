﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetConnect.DAL.Data.Enums;
using PetConnect.DAL.Data.Identity;

namespace PetConnect.DAL.Data.Models
{
    public class Doctor : ApplicationUser
    {
        public decimal PricePerHour { get; set; }
        public string CertificateUrl { get; set; } = null!;
        public PetSpecialty PetSpecialty { get; set; }
    }
}
