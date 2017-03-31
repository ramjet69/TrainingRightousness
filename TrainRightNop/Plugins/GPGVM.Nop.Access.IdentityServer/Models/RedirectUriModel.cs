using Nop.Web.Framework.Mvc;

namespace GPGVM.Nop.Access.IdentityServer.Models
{
    public class RedirectUriModel : BaseNopModel
    {
        public int Id { get; set; }

        
        public string UriName { get; set; }

        public string Uri { get; set; }

        

    }
}
