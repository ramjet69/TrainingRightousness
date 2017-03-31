﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Nop.Web.Framework.Mvc.Routes;

namespace GPGVM.Nop.Access.IdentityServer.Infrastructure
{
    public class RouteProvider : IRouteProvider
    {
        public int Priority
        {
            get
            {
                return 1;
            }
        }

        public void RegisterRoutes(RouteCollection routes)
        {
            ViewEngines.Engines.Insert(0, new EditIdentityEngine());
        }
    }
}