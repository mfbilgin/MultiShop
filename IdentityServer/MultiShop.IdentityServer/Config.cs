// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new[]
        {
            new ApiResource("ResourceCatalog")
            {
                Scopes = { "CatalogFullPermission", "CatalogReadOnly" }
            },
            new ApiResource("ResourceDiscount")
            {
                Scopes = { "DiscountFullPermission" }
            },
            new ApiResource("ResourceOrder")
            {
                Scopes = { "OrderFullPermission" }
            },
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

        public static IEnumerable<ApiScope> ApiScopes => new[]
        {
            new ApiScope("CatalogFullPermission", "Full authority for catalog API"),
            new ApiScope("CatalogReadOnly", "Read only authority for catalog API"),
            new ApiScope("DiscountFullPermission", "Full authority for discount API"),
            new ApiScope("OrderFullPermission", "Full authority for order API")
        };

        public static IEnumerable<Client> Clients => new[]
        {
            new Client
            {
                ClientId = "MultiShopVisitorClientId",
                ClientName = "MultiShop Visitor Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multiShopClientSecret".Sha256())},
                AllowedScopes = {"CatalogReadOnly"}
            },
            
            new Client
            {
                ClientId = "MultiShopManagerClientId",
                ClientName = "MultiShop Manager Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multiShopClientSecret".Sha256())},
                AllowedScopes = {"CatalogFullPermission"}
            },
            new Client
            {
                ClientId = "MultiShopAdminClientId",
                ClientName = "MultiShop Admin Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multiShopClientSecret".Sha256())},
                AllowedScopes =
                {
                    "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime = 600
            },
        };
    }
}