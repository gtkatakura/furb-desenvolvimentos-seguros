using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scutum.WebAPI;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http.SelfHost;

namespace Scutum.UnitTest
{
    [TestClass]
    public class TestChamadoController
    {
        private static Uri baseAddress;
        private static HttpSelfHostConfiguration config;
        private static HttpSelfHostServer server;
        private static HttpClient client;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            baseAddress = new Uri("http://localhost:9001");
            config = new HttpSelfHostConfiguration(baseAddress);

            WebApiConfig.Register(config);

            server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();

            client = new HttpClient
            {
                BaseAddress = baseAddress
            };
        }

        [TestInitialize]
        public void TestInitialize()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "dGFrYXNoaTox"); // credentials = takashi:1
        }

        [TestMethod]
        public void TestGetAuthorizationNull()
        {
            client.DefaultRequestHeaders.Authorization = null;
            var response = client.GetAsync("API/Chamados").Result;

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestMethod]
        public void TestGetUnauthorized()
        {
            var response = client.GetAsync("API/Chamados").Result;

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestMethod]
        public void TestGetNotFound()
        {
            var response = client.GetAsync("API/Chamados/0").Result;

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void TestPostBadRequest()
        {
            var value = new { ID = "ID é um Int32." };
            var response = client.PostAsJsonAsync("API/Chamados", value).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestPostCreated()
        {
            var response = client.PostAsJsonAsync("API/Chamados", new { }).Result;

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void TestPutBadRequest()
        {
            var value = new { ID = "ID é um Int32." };
            var response = client.PutAsJsonAsync("API/Chamados/1", value).Result;
            
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            config.Dispose();
        }
    }
}