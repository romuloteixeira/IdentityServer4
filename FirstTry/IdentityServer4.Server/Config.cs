using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer4.Server
{
    public class Config
    {
        private const string API_NAME = "api1";

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(API_NAME),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256()),
                    },
                    AllowedScopes = { API_NAME },
                },
            };
        }
    }
}
