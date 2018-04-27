using Autofac;
using Autofac.Integration.WebApi;
using Landmark.Remark.Website.DapperMap;
using Owin;
using System.Reflection;
using System.Web.Http;
using System.Web.Routing;

namespace Landmark.Remark.Website
{
    /// <summary>
    /// Start up class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration method to configure startup of application
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration configuration = new HttpConfiguration();
            WebApiConfig.Register(configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //////////////////////////////AUTOFAC CONFIG/////////////////////START

            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            new ServicesRegistry().Register(builder);
            var container = builder.Build();

            // Create the depenedency resolver.
            var resolver = new AutofacWebApiDependencyResolver(container);
            configuration.DependencyResolver = resolver;
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(configuration);
            app.UseWebApi(configuration);

            DapperTransformer.Register();

        }
    }
}