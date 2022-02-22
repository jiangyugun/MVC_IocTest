using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_IocTest.Models.Interface
{
    public interface IProductRepository
    {
        void Create(Products instance);

        void Update(Products instance);

        void Delete(Products instance);

        Products Get(int productID);

        IQueryable<Products> GetAll();

        void SaveChanges();

    }
}
