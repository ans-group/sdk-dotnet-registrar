using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UKFast.API.Client.Models;
using UKFast.API.Client.Registrar.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.Registrar.Operations
{
    public class DomainOperations<T> : RegistrarOperations, IDomainOperations<T> where T : Domain
    {
        public DomainOperations(IUKFastRegistrarClient client) : base(client) { }

        public async Task<IList<T>> GetDomainsAsync(ClientRequestParameters parameters = null)
        {
            return await Client.GetAllAsync(GetDomainsPaginatedAsync, parameters);
        }

        public async Task<Paginated<T>> GetDomainsPaginatedAsync(ClientRequestParameters parameters = null)
        {
            return await this.Client.GetPaginatedAsync<T>("/registrar/v1/domains", parameters);
        }

        public async Task<T> GetDomainAsync(string domainName)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new Client.Exception.UKFastClientValidationException("Invalid domain name");
            }

            return await this.Client.GetAsync<T>($"/registrar/v1/domains/{domainName}");
        }
    }
}
