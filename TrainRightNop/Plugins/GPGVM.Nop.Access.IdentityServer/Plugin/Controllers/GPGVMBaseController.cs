using System.Web.Mvc;
using Nop.Core;
using Nop.Core.Infrastructure;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Security;

namespace GPGVM.Nop.Access.IdentityServer.Plugin.Controllers
{
    [NopHttpsRequirement(SslRequirement.Yes)]
    [AdminValidateIpAddress]
    [AdminAuthorize]
    [AdminAntiForgery]
    [AdminVendorValidation]
    public abstract partial class GPGVMBaseController : BasePluginController
    {
        /// <summary>
        /// Initialize controller
        /// </summary>
        /// <param name="requestContext">Request context</param>
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            //set work context to admin mode
            EngineContext.Current.Resolve<IWorkContext>().IsAdmin = true;

            base.Initialize(requestContext);
        }

        protected ActionResult AccessDeniedView()
        {
            //return new HttpUnauthorizedResult();
            return RedirectToAction("AccessDenied", "Security", new { pageUrl = this.Request.RawUrl });
        }
    }
}