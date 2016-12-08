//using RestSharp;
//using Scutum.ConsoleTest.Serializers;
//using Scutum.WebAPI;
//using System;
//using System.Net;
//using System.Web.Http.SelfHost;

//namespace Scutum.ConsoleTest
//{
//    internal class Program
//    {
//        private static void Main(string[] args)
//        {
//            WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;

//            var baseAddress = "http://localhost:9001";
//            var config = new HttpSelfHostConfiguration(baseAddress);

//            WebApiConfig.Register(config);

//            using (var server = new HttpSelfHostServer(config))
//            {
//                server.OpenAsync().Wait();

//                Console.WriteLine("{0} está disponível.", baseAddress);
//                ExecuteClient();
//                Console.ReadKey();
//            }

//            //var propertiesContractResolver = new PropertiesContractResolver();
//        }

//        private static async void ExecuteClient()
//        {
//            //var scutum = new ScutumClient("http://localhost:9001/API");

//            //scutum.Authorize("takashi", "1");

//            //var chamado = await scutum.Chamados.FindAsync(1);

//            //if (chamado != null)
//            //{
//            //    Console.WriteLine("FindAsync - OK. {0}.", chamado.Id);
//            //}

//            //Console.WriteLine(chamado.Descricao);

//            var client = new RestClient("http://localhost:9001/API");

//            var request = new RestRequest("Chamados");

//            request.AddParameter("id", 1);

//            request.JsonSerializer = new JsonLowerCaseUnderscoreSerializer();
            
//            var response = await client.ExecuteGetTaskAsync<Scutum.Model.Chamado>(request);

//            if (response.Data != null)
//            {
//                Console.WriteLine("ChamadoID = {0}", response.Data.Id);

//                var request2 = new RestRequest("Chamados");
//                request.JsonSerializer = new JsonLowerCaseUnderscoreSerializer();

//                request.AddObject(new Scutum.Model.Chamado
//                {
//                    Descricao = "Testando o caminho inverso",
//                    Titulo = "Funciona!"
//                });

//                var response2 = client.Post<Scutum.Model.Chamado>(request);
//            }

//            //var response = client.Get<Scutum.ConsoleTest.Models.User>(request);
//        }
//    }
//}