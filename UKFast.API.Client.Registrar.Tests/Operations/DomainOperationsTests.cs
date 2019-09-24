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
    public class DomainOperationsTests
    {
        [TestMethod]
        public async Task GetDomainsAsync_ExpectedResult()
        {
            IUKFastRegistrarClient client = Substitute.For<IUKFastRegistrarClient>();

            client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<Domain>>(), null).Returns(Task.Run<IList<Domain>>(() =>
            {
                return new List<Domain>()
                 {
                        new Domain(),
                        new Domain()
                 };
            }));

            var ops = new DomainOperations<Domain>(client);
            var domains = await ops.GetDomainsAsync();

            Assert.AreEqual(2, domains.Count);
        }

        [TestMethod]
        public async Task GetDomainsPaginatedAsync_ExpectedClientCall()
        {
            IUKFastRegistrarClient client = Substitute.For<IUKFastRegistrarClient>();

            client.GetPaginatedAsync<Domain>("/registrar/v1/domains").Returns(Task.Run(() =>
            {
                return new Paginated<Domain>(client, "/registrar/v1/domains", null, new Response.ClientResponse<System.Collections.Generic.IList<Domain>>()
                {
                    Body = new Response.ClientResponseBody<System.Collections.Generic.IList<Domain>>()
                    {
                        Data = new List<Domain>()
                        {
                            new Domain(),
                            new Domain()
                        }
                    }
                });
            }));

            var ops = new DomainOperations<Domain>(client);
            var paginated = await ops.GetDomainsPaginatedAsync();

            Assert.AreEqual(2, paginated.Items.Count);
        }

        [TestMethod]
        public async Task GetDomainAsync_ValidParameters_ExpectedResult()
        {
            IUKFastRegistrarClient client = Substitute.For<IUKFastRegistrarClient>();

            client.GetAsync<Domain>("/registrar/v1/domains/ukfast.co.uk").Returns(new Domain()
            {
                Name = "ukfast.co.uk"
            });

            var ops = new DomainOperations<Domain>(client);
            var domain = await ops.GetDomainAsync("ukfast.co.uk");

            Assert.AreEqual("ukfast.co.uk", domain.Name);
        }

        [TestMethod]
        public async Task GetDomainAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainOperations<Domain>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.GetDomainAsync(""));
        }
    }
}
