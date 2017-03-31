using System.Collections.Generic;
using IdentityServer4.Models;

namespace GPGVM.Nop.Access.IdentityServer.Configuration.Clients
{
    public static class AllowedAuthClients
    {

        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                new Client
                {
                    Enabled = true,
                    ClientName = "",
                    ClientId = "",
                    RequireConsent = true,
                    AllowedGrantTypes = GrantTypes.Hybrid,

                    RedirectUris = new List<string>
                    {
                        
                    }

        
                }



            };
        }

    }
}
