using System.Data.Entity.ModelConfiguration;
using GPGVM.Nop.Access.IdentityServer.Domain;

namespace GPGVM.Nop.Access.IdentityServer.DataMaps
{
    public class ClientConfigurationMap : EntityTypeConfiguration<ClientConfigRecord>
    {
        public ClientConfigurationMap()
        {
            ToTable("GPGVM_Identity_ClientConfig");
            HasKey(m => m.ClientRecordId);
            Property(m => m.ClientId);
            Property(m => m.ClientName);
            Property(m => m.IsConsentRequired);
            Property(m => m.IsEnabled);
            Property(m => m.AllowedGrantTypes);


          

        }
    }
}
