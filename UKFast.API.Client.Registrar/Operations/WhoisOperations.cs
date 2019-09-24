using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UKFast.API.Client.Models;
using UKFast.API.Client.Registrar.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.Registrar.Operations
{
    public class WhoisOperations<T> : RegistrarOperations, IWhoisOperations<T> where T : Whois
    {
        public WhoisOperations(IUKFastRegistrarClient client) : base(client) { }

        public async Task<T> GetWhoisAsync(string domainName)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid domain name");
            }

            return await this.Client.GetAsync<T>($"/registrar/v1/whois/{domainName}");
        }

        public async Task<string> GetWhoisRawAsync(string domainName)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid domain name");
            }

            return await this.Client.GetAsync<string>($"/registrar/v1/whois/{domainName}/raw");
        }
    }
}
