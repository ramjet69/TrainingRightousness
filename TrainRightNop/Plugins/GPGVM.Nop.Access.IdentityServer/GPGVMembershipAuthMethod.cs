using System;
using System.Web.Routing;
using Nop.Core.Plugins;
using Nop.Services.Authentication.External;

namespace GPGVM.Nop.Access.IdentityServer
{
    public class GPGVMembershipAuthMethod : BasePlugin, IExternalAuthenticationMethod
    {
        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            throw new NotImplementedException();
        }

        public void GetPublicInfoRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            throw new NotImplementedException();
        }
    }
}
