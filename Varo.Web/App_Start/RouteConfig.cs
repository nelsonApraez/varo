//// ---------------------------------------------------------------------------
//// <copyright file="RouteConfig.cs">Company S.A.</copyright>
//// <author>Developer</author>
//// <email>developer@company.com</email>
//// <date>06/10/2016</date>
//// <summary>Registra los patrones de url utilizados en la soluci�n.</summary>
//// ---------------------------------------------------------------------------

namespace Varo.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Registra los patrones de url utilizados en la soluci�n.
    /// </summary>
    public static class RouteConfig
    {
        /// <summary>
        /// Registra las url utilizadas en el contexto de la soluci�n.
        /// </summary>
        /// <param name="routes">Colecci�n de rutas a registrar.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

