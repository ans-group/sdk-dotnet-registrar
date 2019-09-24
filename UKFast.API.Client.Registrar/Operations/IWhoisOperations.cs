using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UKFast.API.Client.Registrar.Models;

namespace UKFast.API.Client.Registrar.Operations
{
    public interface IWhoisOperations<T> where T : Whois
    {
        Task<T> GetWhoisAsync(string domainName);
        Task<string> GetWhoisRawAsync(string domainName);
    }
}
