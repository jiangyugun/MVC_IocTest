using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Repository.Models
{
    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
        /// <summary>
     /// Gets the by ID.
     /// </summary>
     /// <param name="productID">The product ID.</param>
     /// <returns></returns>
     /// <exception cref="System.NotImplementedException"></exception>
        public Products GetByID(int productID)
        {
            return this.Get(x => x.ProductID == productID);
        }

        /// <summary>
        /// Gets the by cateogy.
        /// </summary>
        /// <param name="categoryID">The category ID.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Products> GetByCateogy(int categoryID)
        {
            return this.GetAll().Where(x => x.CategoryID == categoryID);
        }
    }
}