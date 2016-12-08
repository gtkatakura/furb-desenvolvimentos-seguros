//using System;
//using System.Net.Http;
//using System.Threading.Tasks;

//namespace Scutum.ConsoleTest
//{
//    internal class Program
//    {
//        private static void Main(string[] args)
//        {
//            //TestHttpsRequest().Wait();
//            //TestBatchRequests().Wait();

//            //var uri = new Uri("http://localhost/5/CadastraSolucao.asp?SessionID=EC81D8D2BCC84ECBA96EB2AF84…D=185&GUIDtramProv=&ChamadoSAC=&idBtnAnexo=&visualiza=1&Pagina=FaleConosco");

//            Console.ReadKey();
//        }

//        private static async Task TestHttpsRequest()
//        {
//            using (var client = new HttpClient())
//            {
//                //ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
//                //var requestUri = new Uri("http://localhost/Scutum/API/Chamados");
//                var requestUri = new Uri("http://localhost:61665/API/Chamados");
//                //var message = await client.GetAsync(requestUri);
//                var message = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, requestUri));

//                Console.WriteLine(message.IsSuccessStatusCode);
//                Console.WriteLine(await message.Content.ReadAsStringAsync());
//            }
//        }

//        private static async Task TestBatchRequests()
//        {
//            using (var client = new HttpClient())
//            {
//                var content = new MultipartContent("mixed", "batch_" + Guid.NewGuid().ToString());

//                content.Add
//                (
//                    new HttpMessageContent
//                    (
//                        new HttpRequestMessage(HttpMethod.Get, "http://localhost:61665/API/Chamados")
//                    )
//                );

//                content.Add
//                (
//                    new HttpMessageContent
//                    (
//                        new HttpRequestMessage(HttpMethod.Get, "http://localhost:61665/API/Tramites")
//                    )
//                );

//                var message = new HttpRequestMessage(HttpMethod.Post, "http://localhost:61665/API/Batch")
//                {
//                    Content = content
//                };

//                using (var responseMultipart = await client.SendAsync(message))
//                {
//                    var multipartMemoryStream = await responseMultipart.Content.ReadAsMultipartAsync();

//                    foreach (var multipartContents in multipartMemoryStream.Contents)
//                    {
//                        var response = await multipartContents.ReadAsHttpResponseMessageAsync();
//                        var result = await response.Content.ReadAsStringAsync();

//                        Console.WriteLine(result);
//                    }
//                }
//            }

//            Console.ReadKey();
//        }
//    }
//}