using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Security.Cryptography;
using Scutum.Library.Security;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Scutum.ConsoleTest
{
    internal class Program
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        private static void Main(string[] args)
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("ScutumWebAPI");

            var collection = _database.GetCollection<Model.Usuario>("usuarios");

            var usuario = collection.Find<Model.Usuario>(x => x.Id == 1).FirstOrDefault();

            Console.WriteLine("Sucesso");

            Console.ReadKey();
        }
    }
}