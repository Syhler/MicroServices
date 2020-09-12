using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;

namespace Auth.Infrastructure.ClientConfig
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client_id_test",
                    ClientSecrets = {new Secret("client.secret".ToSha256())},
                    AllowedScopes = {"openid", "profile"},
                    RequireConsent = false,
                    RedirectUris = {"https://localhost:4200/?????????????"},
                    PostLogoutRedirectUris = {"https://localhost:4200/?????????"},
                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser = true,
                    AllowedCorsOrigins = {"https://localhost:4200"},
                    AllowedGrantTypes = GrantTypes.Implicit
                }
            };
        }
    }
}