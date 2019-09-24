using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UKFast.API.Client.Models;
using UKFast.API.Client.Registrar.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.Registrar.Operations
{
    public class DomainNameserverOperations<T> : RegistrarOperations, IDomainNameserverOperations<T> where T : Nameserver
    {
        public DomainNameserverOperations(IUKFastRegistrarClient client) : base(client) { }

        public async Task<IList<T>> GetDomainNameserversAsync(string domainName, ClientRequestParameters parameters = null)
        {
            return await Client.GetAllAsync((ClientRequestParameters funcParameters) =>
                GetDomainNameserversPaginatedAsync(domainName, funcParameters)
            , parameters);
        }

        public async Task<Paginated<T>> GetDomainNameserversPaginatedAsync(string domainName, ClientRequestParameters parameters = null)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid domain name");
            }

            return await this.Client.GetPaginatedAsync<T>($"/registrar/v1/domains/{domainName}/nameservers", parameters);
        }
    }
}
