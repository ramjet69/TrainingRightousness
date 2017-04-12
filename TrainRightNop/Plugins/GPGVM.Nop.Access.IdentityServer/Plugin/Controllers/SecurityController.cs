using System.Web.Mvc;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Services.Logging;
using Nop.Web.Framework.Controllers;

namespace GPGVM.Nop.Access.IdentityServer.Plugin.Controllers
{
    public class SecurityController : BaseController
    {
        private readonly ILogger _logger;
        private readonly IWorkContext _workContext;

        public SecurityController(ILogger logger, IWorkContext workContext)
        {
            _logger = logger;
            _workContext = workContext;
        }

        public ActionResult AccessDenied(string pageUrl)
        {
            var currentCustomer = _workContext.CurrentCustomer;
            if (currentCustomer == null || currentCustomer.IsGuest())
            {
                _logger.Information(string.Format("Access denied to anonymous request on {0}", pageUrl));
                return View();
            }

            _logger.Information(string.Format("Access denied to user #{0} '{1}' on {2}", currentCustomer.Email, currentCustomer.Email, pageUrl));


            return View();
        }
    }
}