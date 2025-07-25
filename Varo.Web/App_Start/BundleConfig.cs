//// -----------------------------------------------------------------------------------------------
//// <copyright file="BundleConfig.cs">Company S.A.</copyright>
//// <author>Developer</author>
//// <email>developer@company.com</email>
//// <date>06/10/2016</date>
//// <summary>
//// Define los mecanismos de optmización en la adición de recursos en el contexto de la aplicación.
//// </summary>
//// -----------------------------------------------------------------------------------------------

namespace Varo.Web
{
    using System.Web.Optimization;

    /// <summary>
    /// Define los mecanismos de optmización en la adición de recursos en el contexto de la aplicación.
    /// </summary>
    public static class BundleConfig
    {
        /// <summary>
        /// Registra conjuntos de recursos en el contexto de la aplicación.
        /// </summary>
        /// <param name="bundles">Colección de recursos registrados en el contexto.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                      "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/materialize").Include(
                      "~/Scripts/materialize.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom-validator").Include(
                      "~/Scripts/validaciones.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                     "~/Scripts/sweetalert2.js"));
        }
    }
}

