using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;
using Nop.Web.Framework.Mvc;

namespace GPGVM.Nop.Access.IdentityServer.Models
{
    public class ClientConfigurationModel : BaseNopModel
    {
        public int Id { get; set; }

        public bool IsEnabled { get; set; }

        public string ClientName { get; set; }

        public string ClientId { get; set; }

        public bool IsConsentRequired { get; set; }

        public GrantTypes AllowedGrantTypes { get; set; }

        public List<RedirectUriModel> RedirectUris { get; set; }

    }
}
