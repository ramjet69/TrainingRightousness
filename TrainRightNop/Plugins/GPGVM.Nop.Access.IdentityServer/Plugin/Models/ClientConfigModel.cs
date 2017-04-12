using System.Collections.Generic;
using System.Web.Mvc;
using GPGVM.Nop.Access.IdentityServer.Configuration.Infrastructure;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace GPGVM.Nop.Access.IdentityServer.Plugin.Models
{
    public class ClientConfigModel : BaseNopEntityModel
    {


        public virtual int ClientRecordId { get; set; }

        [NopResourceDisplayName("GPGVM.NOP.IdentityServer.Clients.Enabled")]
        [AllowHtml]
        public virtual bool IsEnabled { get; set; }

        [NopResourceDisplayName("GPGVM.NOP.IdentityServer.Clients.ClientName")]
        [AllowHtml]
        public virtual string ClientName { get; set; }

        [NopResourceDisplayName("GPGVM.NOP.IdentityServer.Clients.ClientId")]
        [AllowHtml]
        public virtual string ClientId { get; set; }

        [NopResourceDisplayName("GPGVM.NOP.IdentityServer.Clients.RequireConsent")]
        [AllowHtml]
        public virtual bool IsConsentRequired { get; set; }

        [NopResourceDisplayName("GPGVM.NOP.IdentityServer.Clients.AllowedGrantTypes")]
        [AllowHtml]
        public virtual GrantTypes AllowedGrantTypes { get; set; }

        [NopResourceDisplayName("GPGVM.NOP.IdentityServer.Clients.RedirectUris")]
        [AllowHtml]
        public virtual List<RedirectUriModel> RedirectUris { get; set; } = new List<RedirectUriModel>();


        public virtual  bool isDeleted { get; set; }




    }
}
