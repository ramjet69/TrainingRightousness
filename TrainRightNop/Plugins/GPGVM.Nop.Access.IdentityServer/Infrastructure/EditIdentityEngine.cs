using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nop.Web.Framework.Themes;

namespace GPGVM.Nop.Access.IdentityServer.Infrastructure
{
    public class EditIdentityEngine : ThemeableRazorViewEngine
    {

        public EditIdentityEngine()
        {
            ViewLocationFormats = new []{ "~/Plugins/GPGVM.Nop.Access.IdentityServer/Views/{0}.cshtml" };
            PartialViewLocationFormats = new []{ "~/Plugins/GPGVM.Nop.Access.IdentityServer/Views/{0}.cshtml" };
        }

    }
}