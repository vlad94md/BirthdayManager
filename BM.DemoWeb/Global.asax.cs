using BM.DemoWeb.App_Start;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace BM.DemoWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            Bootstrapper.Run();
        }
    }
}
