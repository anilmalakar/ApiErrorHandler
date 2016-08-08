using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ApiErrorHandler.Models;
using ApiErrorHandler.Repository;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ApiErrorHandler.Controllers
{
    /// <summary>
    /// Error Controller is used to get the Error collection from mongo db and pass it on to view.
    /// </summary>
    public class ErrorController : BaseResponseController
    {
        private readonly IBaseRepository<ErrorEntity> _errorRepository;
        public ErrorController(IBaseRepository<ErrorEntity> errorRepository, IBaseRepository<ErrorEntity> _errorsRepository)
            : base(_errorsRepository)
        {
            _errorRepository = errorRepository;
        }


        public ErrorController()
        {
            _errorRepository = new BaseRepository<ErrorEntity>();
        }


        [Route("api/Errors")]
        public async Task<IEnumerable<ErrorEntity>> GetErrors()
        {
            var recentErrors = await _errorRepository.Get("Errors").Find(new BsonDocument())
                .Sort(Builders<ErrorEntity>.Sort.Ascending("CreatedDate"))
                .Limit(10).ToListAsync();
           
            return recentErrors;
        }
     
        [Route("api/AddError")]
        [HttpPost]
        public HttpResponseMessage Add(HttpRequestMessage request, [FromBody] ErrorEntity errorEntity)
        {
            return CaptureResponseMessage(request, () =>
            {
                HttpResponseMessage response = null;
                _errorRepository.Add(errorEntity, "Errors");
                response = request.CreateResponse(HttpStatusCode.OK, errorEntity);

                return response;
            });
        }
        // POST: api/Error
        public void Post([FromBody]string value)
        {
        }
    }
}
