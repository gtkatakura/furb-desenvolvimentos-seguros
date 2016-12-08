//using RestSharp;
//using Scutum.Model;
//using Scutum.WebAPI.Client;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using todoistsharp;

//namespace Scutum.ConsoleTest
//{
//    internal class Program
//    {
//        private static void Main(string[] args)
//        {
//            WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;

//            var todoist = new Todoist();

//            todoist.Login(ConfigurationManager.AppSettings["TodoistUsername"], ConfigurationManager.AppSettings["TodoistPassword"]);

//            var project = todoist.AddProject("Chamados");
            
//            var item = todoist.AddItem(project.id, "Teste&", priority:1);

//            Console.WriteLine("Projeto e Item cadastrado.");
//            Console.ReadKey();

//            todoist.DeleteProject(project.id);
//        }
//    }
//}