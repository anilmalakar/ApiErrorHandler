using System;
using ApiErrorHandler.Models;
using MongoDB.Driver;

namespace ApiErrorHandler.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {

        readonly DbContext _dbContext = new DbContext();
        public IMongoCollection<T> Get(string collectionName)
        {
            return _dbContext.Database.GetCollection<T>(collectionName);
        }

        public void Add(T entity, string collectionName)
        {
            _dbContext.Database.GetCollection<T>(collectionName).InsertOne(entity);
        }

        public void Remove(int errorId)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }


        //public async Task<IEnumerable<BaseError>> GetErrors()
        //{
        //    var recentErrors = await dbContext.Errors.Find(new BsonDocument())
        //        .Sort(Builders<BaseError>.Sort.Ascending("CreatedDate"))
        //        .Limit(10).ToListAsync();

        //    return recentErrors;
        //}

        //public Models.BaseError GetErrorByType(string errorType)
        //{
        //    throw new NotImplementedException();
        //}

        //public void InsertError(Models.BaseError error)
        //{
        //    //var err = new BaseError
        //    //{
        //    //    ErrorMessage = "Exception from Service",
        //    //    ErrorType = "General Error",
        //    //    StackTrace = "Admin"
        //    //};

        //    dbContext.Errors.InsertOneAsync(error);
        //}




    }
}