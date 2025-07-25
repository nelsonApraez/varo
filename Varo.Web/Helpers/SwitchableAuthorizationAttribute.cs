

namespace Varo.Web.Helpers
{
    using System;
    using System.Web;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate)]
    public sealed class SwitchableAuthorizationAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
#if DEBUG
            return true;
#else
                return base.AuthorizeCore(httpContext);
#endif
        }
    }
}
