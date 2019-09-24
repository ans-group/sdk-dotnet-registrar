using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.Operations;

namespace UKFast.API.Client.Registrar.Operations
{
    public class RegistrarOperations : OperationsBase<IUKFastRegistrarClient>
    {
        public RegistrarOperations(IUKFastRegistrarClient client) : base(client) { }
    }
}
