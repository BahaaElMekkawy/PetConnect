using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetConnect.DAL.Data.Identity;
using PetConnect.DAL.Data.Models;


namespace PetConnect.DAL.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {

        public DbSet<Pet> Pets { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }



    }
}
