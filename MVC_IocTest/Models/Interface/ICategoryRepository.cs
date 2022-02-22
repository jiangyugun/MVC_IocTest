using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_IocTest.Models.Interface
{
    public interface ICategoryRepository
    {
        void Create(Categories instance);

        void Update(Categories instance);

        void Delete(Categories instance);

        Categories Get(int categoryID);

        IQueryable<Categories> GetAll();

        void SaveChanges();
    }
}