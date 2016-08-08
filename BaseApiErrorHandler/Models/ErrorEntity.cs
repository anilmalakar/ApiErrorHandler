using MongoDB.Bson;
using System;

namespace ApiErrorHandler.Models
{
    public class ErrorEntity
    {
        public BsonObjectId Id { get; set; } 
        public string ErrorMessage { get; set; } 
        public string StackTrace { get; set; }
        public string ErrorType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}