using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook
{
    public static class KeyVaultService
    {
        public static string  CacheConnection { get; set; }

        public static async Task<string> GetToken(string authority,string resource,string scope)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var authContext = new AuthenticationContext(authority);
            ClientCredential clientCred = new ClientCredential(config["ClientId"], config["ClientSecret"]);

            AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);

            if (result == null)
                throw new InvalidOperationException("Failed to obtain the JWT token");

            return result.AccessToken;
        }
    }
}
