using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetConnect.BLL.Common.AttachmentServices;
using PetConnect.BLL.Services.Classes;
using PetConnect.BLL.Services.Interfaces;
using PetConnect.DAL.Data;
using PetConnect.DAL.Data.Identity;

namespace PetConnect.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Services
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));

            });
            //Repositories Services register
            RepositoriesCollectionExtensions.AddDalRepositories(builder.Services);

            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<AppDbContext>();


            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddScoped<IAttachmentService, AttachmentService>();
            

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
