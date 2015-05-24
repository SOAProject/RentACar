using Microsoft.Practices.Unity;
using RentACar.Api.Data;
using RentACar.Api.Models;
using System.Web.Http;
using Unity.WebApi;

namespace RentACar.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IRepository<Car>, EFRepository<Car>>();
            container.RegisterType<IRepository<Rent>, EFRepository<Rent>>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}