using System.Collections.Generic;
using Nop.Core;

namespace GPGVM.Nop.Access.IdentityServer.Domain
{
    public class ClientConfigRecord : BaseEntity
    {
        public virtual int ClientRecordId { get; set; }

        public virtual bool IsEnabled { get; set; }

        public virtual string ClientName { get; set; }

        public virtual string ClientId { get; set; }

        public virtual bool IsConsentRequired { get; set; }

        public virtual int AllowedGrantTypes { get; set; }

        public virtual List<RedirectUriRecord> RedirectUris { get; set; } = new List<RedirectUriRecord>();
    }
}
