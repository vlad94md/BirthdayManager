using System.Web.Mvc;
using System.Web.Routing;

namespace BM.DemoWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Catchall",
                url: "{*catchall}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
