using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace ApiErrorHandler.Models
{
    public class DbContext
    {
        public static string CONNECTION_STRING_NAME = "ErrorDb";
        public static string DATABASE_NAME = "ErrorDb";
        public static string Errors_COLLECTION_NAME = "Errors";

        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;
        static DbContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME].ConnectionString;
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(DATABASE_NAME);
        }

        //public string ErrorCollection
        //{
        //    get { return Errors_COLLECTION_NAME; }
        //}
        public IMongoClient Client
        {
            get { return _client; }
        }
        public IMongoDatabase Database
        {
            get { return _database; }
        }
        //public IMongoCollection<ErrorEntity> Errors
        //{
        //    get { return _database.GetCollection<ErrorEntity>(Errors_COLLECTION_NAME); }
        //}
    }
}