using System.Web.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace GPGVM.Nop.Access.IdentityServer.Plugin.Models
{
    public class RedirectUriModel : BaseNopEntityModel
    {

        public virtual int ClientRecordId { get; set; }

        [NopResourceDisplayName("GPGVM.NOP.IdentityServer.Clients.RedirectUriName")]
        [AllowHtml]
        public virtual string UriName { get; set; }

        [NopResourceDisplayName("GPGVM.NOP.IdentityServer.Clients.RedirectUri")]
        [AllowHtml]
        public virtual string Uri { get; set; }
        
    }
}
