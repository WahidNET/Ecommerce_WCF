using System.Web.Mvc;
using System.Web.Routing;

namespace WebStoreMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Produits", action = "Index", id = UrlParameter.Optional },
              namespaces: new string[] { "WebStoreMVC.Controllers" }
            );
        }
    }
}
