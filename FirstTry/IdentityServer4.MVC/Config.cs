using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer4.MVC
{
    public class Config
    {
        private const string API_RESOURCE_NAME = "MVC";

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(API_RESOURCE_NAME, "My Api"),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                }
            };
            //return new List<Client>
            //{
            //    new Client
            //    {
            //        ClientId = "mvc",
            //        ClientName = "MVC Client",
            //        AllowedGrantTypes = GrantTypes.ClientCredentials,
            //        RequireConsent = false,
            //        ClientSecrets =
            //        {
            //            new Secret("secret".Sha256()),
            //        },
            //        RedirectUris = { "http://localhost:5002/signin-oidc" },
            //        PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },
            //        AllowedScopes = 
            //        { 
            //            IdentityServerConstants.StandardScopes.OpenId,
            //            IdentityServerConstants.StandardScopes.Profile,
            //            API_RESOURCE_NAME,
            //        },
            //        AllowOfflineAccess = true,
            //    },
            //};
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
    }
}
