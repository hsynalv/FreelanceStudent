using System;
using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace FreelanceStudent.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources => new ApiResource[]
        {
            new ApiResource("resource_API")
            {
                Scopes = {"API_full_permission" },
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {
                new ApiScope("API_full_permission","API için okuma izni"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };
        }


        public static IEnumerable<IdentityResource> GetIdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),  // Olmazsa olmaz!!!
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };


        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientId = "Client1",
                    ClientName = "Client 1 web uygulaması",
                    ClientSecrets = new []{new Secret("Secret1".Sha512())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes =
                    {
                        IdentityServerConstants.LocalApi.ScopeName,
                    },
                },

                new Client
                {
                    ClientId="js-client",
                    RequireClientSecret=false,
                    ClientName="Js Client Angular",
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityServerConstants.StandardScopes.Email,
                        "API_full_permission",
                    },
                    RedirectUris= { "http://localhost:4200/callback" },
                    AllowedCorsOrigins = { "http://localhost:4200/" },
                    PostLogoutRedirectUris = { "http://localhost:4200/" }
                },

                new Client
                {
                    ClientId = "Client1-ResourceOwner-Mvc",
                    ClientName = "Client 1 MVC Uygulaması",
                    ClientSecrets = new []{new Secret("Secret".Sha512())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.LocalApi.ScopeName,
                        "API_full_permission",
                    },
                    AccessTokenLifetime = 2*60*60,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    AbsoluteRefreshTokenLifetime = (int)(DateTime.Now.AddDays(60) - DateTime.Now).TotalSeconds,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    AllowOfflineAccess=true,
                }

            };
        }
    }
}