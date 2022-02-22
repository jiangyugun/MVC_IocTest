using Mvc_Repository.Models;
using Mvc_Repository.Models.DbContextFactory;
using Mvc_Repository.Service;
using Mvc_Repository.Service.Interface;
using System.Data.Entity.Infrastructure;
using System.Web.Configuration;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace MVC_IocTest
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            string connectionString = WebConfigurationManager.ConnectionStrings["TestDbEntities"].ConnectionString;

            container.RegisterType<IDbContextFactory, DbContextFactory>(
                new HierarchicalLifetimeManager(),
                new InjectionConstructor(connectionString));

            // Repository
            container.RegisterType<IRepository<Categories>, GenericRepository<Categories>>();
            container.RegisterType<IRepository<Products>, GenericRepository<Products>>();

            // Service
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IProductService, ProductService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}