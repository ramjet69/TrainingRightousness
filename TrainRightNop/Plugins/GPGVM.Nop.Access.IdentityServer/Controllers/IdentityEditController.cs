﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GPGVM.Nop.Access.IdentityServer.Domain;
using Nop.Core.Data;
using Nop.Web.Framework.Controllers;

namespace GPGVM.Nop.Access.IdentityServer.Controllers
{
    [AdminAuthorize]
    public class IdentityEditController : BasePluginController
    {

        private IRepository<ClientConfigRecord> _clientConfigRecord;
        private IRepository<RedirectUriRecord> _redirectUriRecord;


        public IdentityEditController(IRepository<ClientConfigRecord> clientConfigRecord, IRepository<RedirectUriRecord> redirectUriRecord)
        {
            _clientConfigRecord = clientConfigRecord;
            _redirectUriRecord = redirectUriRecord;
        }


        public ActionResult LoadIdentityEdit(int? tabindex)
        {
            return View();
        }
        

    }
}