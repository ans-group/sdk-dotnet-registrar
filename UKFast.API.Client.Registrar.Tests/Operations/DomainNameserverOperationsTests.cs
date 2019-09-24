using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.Registrar.Models;
using UKFast.API.Client.Registrar.Operations;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;

namespace UKFast.API.Client.Registrar.Operations.Tests
{
    [TestClass]
    public class DomainNameserverOperationsTests
    {
        [TestMethod]
        public async Task GetDomainNameserversAsync_ExpectedResult()
        {
            IUKFastRegistrarClient client = Substitute.For<IUKFastRegistrarClient>();

            client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<Nameserver>>(), null).Returns(Task.Run<IList<Nameserver>>(() =>
            {
                return new List<Nameserver>()
                 {
                        new Nameserver(),
                        new Nameserver()
                 };
            }));

            var ops = new DomainNameserverOperations<Nameserver>(client);
            var nameservers = await ops.GetDomainNameserversAsync("ukfast.co.uk");

            Assert.AreEqual(2, nameservers.Count);
        }

        [TestMethod]
        public async Task GetDomainNameserversPaginatedAsync_ExpectedClientCall()
        {
            IUKFastRegistrarClient client = Substitute.For<IUKFastRegistrarClient>();

            client.GetPaginatedAsync<Nameserver>("/registrar/v1/domains/ukfast.co.uk/nameservers").Returns(Task.Run(() =>
            {
                return new Paginated<Nameserver>(client, "/registrar/v1/domains/ukfast.co.uk/nameservers", null, new Response.ClientResponse<System.Collections.Generic.IList<Nameserver>>()
                {
                    Body = new Response.ClientResponseBody<System.Collections.Generic.IList<Nameserver>>()
                    {
                        Data = new List<Nameserver>()
                        {
                            new Nameserver(),
                            new Nameserver()
                        }
                    }
                });
            }));

            var ops = new DomainNameserverOperations<Nameserver>(client);
            var paginated = await ops.GetDomainNameserversPaginatedAsync("ukfast.co.uk");

            Assert.AreEqual(2, paginated.Items.Count);
        }

        [TestMethod]
        public async Task GetDomainNameserversPaginatedAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainNameserverOperations<Nameserver>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.GetDomainNameserversPaginatedAsync(""));
        }
    }
}
