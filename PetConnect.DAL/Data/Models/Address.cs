﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.DAL.Data.Models
{

    public class Address
    {
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Street { get; set; } = null!;
    }
}
