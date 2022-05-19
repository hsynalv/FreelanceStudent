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
            new ApiResource("resource_api1")
            {
                Scopes = {"api1.read", "api1.write", "api1.update" },
                ApiSecrets = new[]{new Secret("secretApi1".Sha512())},  // Basic Auth Doğrulama için 
            },
            new ApiResource("resource_api2")
            {
                Scopes = {"api2.read", "api2.write", "api2.update" },
                ApiSecrets = new[]{new Secret("secretApi2".Sha512())},  // Basic Auth Doğrulama için 
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {
                new ApiScope("api1.read","API 1 için okuma izni"),
                new ApiScope("api1.write","API 1 için write izni"),
                new ApiScope("api1.update","API 1 için update izni"),
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
                    AllowedScopes = { "api1.read" }
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
                        "api1.read",
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
                        "api1.read",
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