using Microsoft.Practices.Unity;
using System.Web.Http;
using TrainRightApi.Repository;
using Unity.WebApi;

namespace TrainRightApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<ITrainRightRepository, TrainRightRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}