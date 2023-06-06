using SchoolManagement_340.Repository.Repository;
using SchoolManagement_340.Repository.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace SchoolManagement_340
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IUserPanel_Interface, UserPanel_Services>();
            container.RegisterType<ICountryInterface, CountryServices>();
            container.RegisterType<IStateInterface, StateServices>();
            container.RegisterType<ICityInterface, CityServices>();
            container.RegisterType<IStudentInterface, StudentServices>();

            // register all your components with the container heres
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}