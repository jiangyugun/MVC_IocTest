using Mvc_Repository.Models;
using Mvc_Repository.Service.Interface;
using Mvc_Repository.Service.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Repository.Service
{
    public class ProductService : IProductService
    {
        //private IRepository<Products> repository = new GenericRepository<Products>();

        private IRepository<Products> _repository;

        public ProductService(IRepository<Products> repository)
        {
            this._repository = repository;
        }

        public Misc.IResult Create(Products instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                this._repository.Create(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Update(Products instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                this._repository.Update(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Delete(int productID)
        {
            IResult result = new Result(false);

            if (!this.IsExists(productID))
            {
                result.Message = "找不到資料";
            }

            try
            {
                var instance = this.GetByID(productID);
                this._repository.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public bool IsExists(int productID)
        {
            return this._repository.GetAll().Any(x => x.ProductID == productID);
        }

        public Products GetByID(int productID)
        {
            return this._repository.Get(x => x.ProductID == productID);
        }

        public IEnumerable<Products> GetAll()
        {
            return this._repository.GetAll();
        }

        public IEnumerable<Products> GetByCategory(int categoryID)
        {
            return this._repository.GetAll().Where(x => x.CategoryID == categoryID);
        }
    }
}
