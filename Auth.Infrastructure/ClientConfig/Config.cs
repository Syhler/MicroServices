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
                new ApiResource("emailService")
                {
                    Scopes = new List<string>{"emailService"}
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("emailService", "Email Service")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "angular_client",
                    ClientSecrets = {new Secret("client.secret".ToSha256())},
                    AllowedScopes = {"openid", "profile", "emailService"},
                    RequireConsent = false,
                    RedirectUris = {"https://localhost:4200"},
                    PostLogoutRedirectUris = {"https://localhost:4200"},
                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser = true,
                    AllowedCorsOrigins = {"https://localhost:4200"},
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true
                }
            };
        }
    }
}