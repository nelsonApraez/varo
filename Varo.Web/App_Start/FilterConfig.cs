//// ----------------------------------------------------------------------
//// <copyright file="FilterConfig.cs" company="Company S.A.">
////     COPYRIGHT(C) 2018, Company S.A.
//// </copyright>
//// <author>Developer</author>
//// <email>developer@company.com</email>
//// <date>09/08/2018</date>
//// <summary>Extiende los filtros existentes en el Framork MVC.</summary>
//// ----------------------------------------------------------------------

namespace Varo.Web
{
    using Varo.Web.ErrorHandler;
    using System.Web.Mvc;

    /// <summary>
    /// Extiende los filtros existentes en el Framework MVC.
    /// </summary>
    public static class FilterConfig
    {
        /// <summary>
        /// Registra las extensiones personalizadas en el contexto de ejecución.
        /// </summary>
        /// <param name="filters">Filtros del contexto de ejecución.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AiHandleErrorAttribute());
        }
    }
}

