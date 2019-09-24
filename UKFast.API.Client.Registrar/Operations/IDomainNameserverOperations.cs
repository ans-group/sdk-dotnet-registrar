using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UKFast.API.Client.Models;
using UKFast.API.Client.Registrar.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.Registrar.Operations
{
    public interface IDomainNameserverOperations<T> where T : Nameserver
    {
        Task<IList<T>> GetDomainNameserversAsync(string domainName, ClientRequestParameters parameters = null);
        Task<Paginated<T>> GetDomainNameserversPaginatedAsync(string domainName, ClientRequestParameters parameters = null);
    }
}
