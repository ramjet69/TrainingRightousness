using Nop.Core;

namespace GPGVM.Nop.Access.IdentityServer.Plugin.Domain
{
    public class RedirectUriRecord : BaseEntity
    {
        public virtual int ClientRecordId { get; set; }

        public virtual string UriName { get; set; }

        public virtual string Uri { get; set; }

        public ClientConfigRecord ClientConfiguration { get; set; }

    }
}
