using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetConnect.DAL.Data.Repositories.Classes;
using PetConnect.DAL.Data.Repositories.Interfaces;
using PetConnect.DAL.UnitofWork;

namespace PetConnect.DAL.Services
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddDalRepositories(this IServiceCollection services)
        {
            // Services 


            return services;
        }
    }
}
