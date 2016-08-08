using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace ApiErrorHandler.Models
{
    public class UserEntity
    {
        public BsonObjectId UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}