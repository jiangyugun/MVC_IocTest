using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_IocTest.Models.Interface
{
    public interface ICategoryRepository: IRepository<Categories>
    {
        Categories GetByID(int categoryID);
    }
}