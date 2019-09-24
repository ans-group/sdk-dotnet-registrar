using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Registrar.Models;
using UKFast.API.Client.Registrar.Operations;

namespace UKFast.API.Client.Registrar.Tests.Operations
{

    [TestClass]
    public class WhoisOperationsTests
    {
        [TestMethod]
        public async Task GetWhoisAsync_ValidParameters_ExpectedResult()
        {
            IUKFastRegistrarClient client = Substitute.For<IUKFastRegistrarClient>();

            client.GetAsync<Whois>("/registrar/v1/whois/ukfast.co.uk").Returns(new Whois()
            {
                Name = "ukfast.co.uk"
            });

            var ops = new WhoisOperations<Whois>(client);
            var whois = await ops.GetWhoisAsync("ukfast.co.uk");

            Assert.AreEqual("ukfast.co.uk", whois.Name);
        }

        [TestMethod]
        public async Task GetWhoisAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new WhoisOperations<Whois>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.GetWhoisAsync(""));
        }

        [TestMethod]
        public async Task GetWhoisRawAsync_ValidParameters_ExpectedResult()
        {
            IUKFastRegistrarClient client = Substitute.For<IUKFastRegistrarClient>();

            client.GetAsync<string>("/registrar/v1/whois/ukfast.co.uk/raw").Returns("rawwhois");

            var ops = new WhoisOperations<Whois>(client);
            var whois = await ops.GetWhoisRawAsync("ukfast.co.uk");

            Assert.AreEqual("rawwhois", whois);
        }

        [TestMethod]
        public async Task GetWhoisRawAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new WhoisOperations<Whois>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.GetWhoisRawAsync(""));
        }
    }
}
