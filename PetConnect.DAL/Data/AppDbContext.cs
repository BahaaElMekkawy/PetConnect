using Microsoft.EntityFrameworkCore;
using PetConnect.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.DAL.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Pet> Pets { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }



    }
}
