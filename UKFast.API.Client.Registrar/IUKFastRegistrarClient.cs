using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.Registrar.Models;
using UKFast.API.Client.Registrar.Operations;

namespace UKFast.API.Client.Registrar
{
    public interface IUKFastRegistrarClient : IUKFastClient
    {
        IDomainOperations<Domain> DomainOperations();
    }
}
