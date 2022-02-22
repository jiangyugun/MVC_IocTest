using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mvc_Repository.Models
{
    public class CategoryRepository : GenericRepository<Categories>, ICategoryRepository
    {
        /// <summary>
        /// Gets the by ID.
        /// </summary>
        /// <param name="categoryID">The category ID.</param>
        /// <returns></returns>
        public Categories GetByID(int categoryID)
        {
            return this.Get(x => x.CategoryID == categoryID);
        }
    }
}