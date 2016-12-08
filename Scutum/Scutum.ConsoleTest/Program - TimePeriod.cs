//using Itenso.TimePeriod;
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
//            var datasPausa = new String[][]
//            {
//                new string[] { "05/02/2014 10:00", "05/02/2014 11:00"}, // 00:00
//                new string[] { "05/02/2014 10:00", "05/02/2014 13:00"}, // 01:00
//                new string[] { "05/02/2014 13:00", "05/02/2014 17:00"}, // 04:00
//                new string[] { "05/02/2014 13:00", "05/02/2014 19:00"}, // 05:00
//                new string[] { "05/02/2014 18:00", "05/02/2014 19:00"} // 00:00
//            };

//            foreach (var dataPausa in datasPausa)
//            {
//                var dataInicial = DateTime.Parse("05/02/2014 12:00");
//                var dataFinal = DateTime.Parse("05/02/2014 18:00");

//                var dataInicialPausa = DateTime.Parse(dataPausa[0]);
//                var dataFinalPausa = DateTime.Parse(dataPausa[1]);

//                var timeInterval = new TimeInterval(dataInicial, dataFinal);
//                var timeIntervalPausa = new TimeInterval(dataInicialPausa, dataFinalPausa);

//                var intersection = timeInterval.GetIntersection(timeIntervalPausa);
//                var duration = intersection == null ? TimeSpan.Zero : intersection.Duration;

//                Console.WriteLine("Framework - {0:00}:{1:00}", duration.TotalHours, duration.Minutes);

//                // Normal

//                duration = TimeSpan.Zero;

//                if (dataInicial < dataFinalPausa && dataFinal > dataInicialPausa)
//                {
//                    var dataI = dataInicial > dataInicialPausa ? dataInicial : dataInicialPausa;
//                    var dataF = dataFinal < dataFinalPausa ? dataFinal : dataFinalPausa;

//                    duration = dataF.Subtract(dataI);
//                }

//                Console.WriteLine("Normal - {0:00}:{1:00}", duration.TotalHours, duration.Minutes);
//            }

//            Console.ReadKey();
//        }
//    }
//}