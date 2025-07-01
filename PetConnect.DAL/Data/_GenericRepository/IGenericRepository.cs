using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.DAL.Data.GenericRepository
{
    internal interface IGenericRepository<T>   // T > Entity
    {

        public IEnumerable<T> GetAll(); // Get All T

        public T? GetByID(int id); // Get Element By Id

        public void Add(T entity); // Add entity record to DbSet

        public void Update(T entity); // update entity data from existing DbSet

        public void Delete(T entity); // delete entity data from existing DbSet

    }
}
