using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UKFast.API.Client.Models;
using UKFast.API.Client.Registrar.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.Registrar.Operations
{
    public interface IDomainOperations<T> where T : Domain
    {
        Task<IList<T>> GetDomainsAsync(ClientRequestParameters parameters = null);
        Task<Paginated<T>> GetDomainsPaginatedAsync(ClientRequestParameters parameters = null);
        Task<T> GetDomainAsync(string domainName);
    }
}
