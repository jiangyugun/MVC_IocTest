using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Repository.Models
{
    public interface IProductRepository : IRepository<Products>
    {
        Products GetByID(int productID);

        IEnumerable<Products> GetByCateogy(int categoryID);
    }
}
