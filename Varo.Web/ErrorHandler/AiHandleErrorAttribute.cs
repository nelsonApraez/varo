//// -----------------------------------------------------------------------------------------------
//// <copyright file="AiHandleErrorAttribute.cs">Company S.A.</copyright>
//// <author>Developer</author>
//// <email>developer@company.com</email>
//// <date>06/10/2016</date>
//// <summary>
//// Implementaci�n que permite interoperar con las Api de Application Insight.
//// </summary>
//// -----------------------------------------------------------------------------------------------

namespace Varo.Web.ErrorHandler
{
    using Microsoft.ApplicationInsights;
    using System;
    using System.Web.Mvc;

    /// <summary>
    /// Implementaci�n que permite interoperar con las Api de Application Insight.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public sealed class AiHandleErrorAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// Ocurre cuando se captura una excepci�n.
        /// </summary>
        /// <param name="filterContext">Stack de la excepci�n.</param>
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext != null && filterContext.HttpContext != null && filterContext.Exception != null)
            {
                //If customError is Off, then AI HTTPModule will report the exception
                if (filterContext.HttpContext.IsCustomErrorEnabled)
                {
                    TelemetryClient telemetryClient = new TelemetryClient();
                    telemetryClient.TrackException(filterContext.Exception);
                }
            }

            base.OnException(filterContext);
        }
    }
}
