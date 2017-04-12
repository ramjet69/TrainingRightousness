using System.Collections.Generic;
using GPGVM.Nop.Access.IdentityServer.Configuration.Infrastructure;
using Nop.Core;
using Nop.Web.Framework;

namespace GPGVM.Nop.Access.IdentityServer.Plugin.Domain
{
    public class ClientConfigRecord : BaseEntity
    {
        public virtual int ClientRecordId { get; set; }

        public virtual bool IsEnabled { get; set; }

        public virtual string ClientName { get; set; }

        public virtual string ClientId { get; set; }

        public virtual bool IsConsentRequired { get; set; }

        public virtual GrantTypes AllowedGrantTypes { get; set; }

        public virtual List<RedirectUriRecord> RedirectUris { get; set; } = new List<RedirectUriRecord>();

        public virtual  bool isDeleted { get; set; }




    }
}
