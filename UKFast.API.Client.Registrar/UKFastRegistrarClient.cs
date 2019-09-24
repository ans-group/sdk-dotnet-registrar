using System;
using UKFast.API.Client.Registrar.Models;
using UKFast.API.Client.Registrar.Operations;

namespace UKFast.API.Client.Registrar
{
    public class UKFastRegistrarClient : UKFastClient, IUKFastRegistrarClient
    {
        public UKFastRegistrarClient(IConnection connection) : base(connection)
        {
        }

        public UKFastRegistrarClient(IConnection connection, ClientConfig config) : base(connection, config)
        {
        }

        public IDomainOperations<Domain> DomainOperations()
        {
            return new DomainOperations<Domain>(this);
        }

        public IDomainNameserverOperations<Nameserver> DomainNameserverOperations()
        {
            return new DomainNameserverOperations<Nameserver>(this);
        }

        public IWhoisOperations<Whois> WhoisOperations()
        {
            return new WhoisOperations<Whois>(this);
        }
    }
}
