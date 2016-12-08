//using NLog;
//using RestSharp;
//using Scutum.Model;
//using Scutum.WebAPI.Client;
//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Threading.Tasks;

//namespace Scutum.ConsoleTest
//{
//    internal class Program
//    {
//        private static Logger logger = LogManager.GetCurrentClassLogger();

//        private static void Main(string[] args)
//        {
//            logger.Trace("Sample trace message");
//            logger.Debug("Sample debug message");
//            logger.Info("Sample informational message");
//            logger.Warn("Sample warning message");
//            logger.Error("Sample error message");
//            logger.Fatal("Sample fatal error message");

//            try
//            {
//                int zero = 0;
//                int result = 5 / zero;
//            }
//            catch (DivideByZeroException ex)
//            {
//                // add custom message and pass in the exception
//                logger.ErrorException("Whoops!", ex);
//            }

//            // alternatively you can call the Log() method
//            // and pass log level as the parameter.
//            logger.Log(LogLevel.Info, "Sample informational message");

//            Console.ReadKey();
//        }
//    }
//}