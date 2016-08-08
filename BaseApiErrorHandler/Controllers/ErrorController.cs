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
        // GET: api/Error/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/AddError")]
        [HttpPost]
        public HttpResponseMessage Add(HttpRequestMessage request, [FromBody] ErrorEntity errorEntity)
        {
            return CaptureResponseMessage(request, () =>
            {
                HttpResponseMessage response = null;
                errorEntity = null;
                _errorRepository.Add(errorEntity, "Errors");
                response = request.CreateResponse(HttpStatusCode.OK, errorEntity);

                return response;
            });
        }
        // POST: api/Error
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Error/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Error/5
        public void Delete(int id)
        {
        }
    }
}
