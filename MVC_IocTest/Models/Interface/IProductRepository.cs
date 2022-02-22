﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_IocTest.Models.Interface
{
    public interface IProductRepository : IRepository<Products>
    {
        Products GetByID(int productID);

        IEnumerable<Products> GetByCateogy(int categoryID);
    }
}
