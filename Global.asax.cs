using Autofac;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac.Integration.WebApi;
using ExampleInject.Infrastructure.AppSettings;
using ExampleInject.Infrastructure.Extensions;

namespace ExampleInject
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var builder = new ContainerBuilder();

            // Configure options  
            builder.AddOptions<ServiceSettings>("services");

            //// Wire up with MVC WebAPI  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var webApiResolver = new AutofacWebApiDependencyResolver(builder.Build());
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
        }
    }
}
