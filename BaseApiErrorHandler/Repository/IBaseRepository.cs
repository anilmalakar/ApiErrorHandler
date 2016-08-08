using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApiErrorHandler.Models;
using MongoDB.Driver;

namespace ApiErrorHandler.Repository
{
    public interface IBaseRepository<T>  where T : class, new()
    {
        IMongoCollection<T> Get(string collectionName);
        void Add(T entity, string collectionName);
        void Remove(int errorId);
        void Update(T entity);
        void Save();
    }
}