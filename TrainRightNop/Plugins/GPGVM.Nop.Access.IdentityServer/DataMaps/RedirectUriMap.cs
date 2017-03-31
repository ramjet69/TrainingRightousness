using System.Data.Entity.ModelConfiguration;
using GPGVM.Nop.Access.IdentityServer.Domain;

namespace GPGVM.Nop.Access.IdentityServer.DataMaps
{
    public class RedirectUriMap : EntityTypeConfiguration<RedirectUriRecord>
    {
        public RedirectUriMap()
        {
            ToTable("GPGVM_Identity_RedirectUris");
            HasKey(m => m.Id);
            Property(m => m.ClientRecordId);
            Property(m => m.UriName);
            Property(m => m.Uri);

            this.HasRequired(i => i.ClientConfiguration)
                .WithMany(s => s.RedirectUris)
                .HasForeignKey(i => i.ClientRecordId);

        }
    }
}
