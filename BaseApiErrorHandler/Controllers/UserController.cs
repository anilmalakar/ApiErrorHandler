using ApiErrorHandler.Models;
using ApiErrorHandler.Repository;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ApiErrorHandler.Controllers
{
    public class UserController : BaseResponseController
    {
        private readonly IBaseRepository<UserEntity> _userRepository;

        public UserController(IBaseRepository<UserEntity> userRepository,  IBaseRepository<ErrorEntity> _errorsRepository)
            : base(_errorsRepository)
        {
            _userRepository = userRepository;
        }

  
        public UserController()
        {
            _userRepository = new BaseRepository<UserEntity>();
        }

        //[Route("api/Users")]
        //public async Task<IEnumerable<UserEntity>> GetErrors()
        //{
        //    var recentUsers = await _userRepository.Get("Users").Find(new BsonDocument())
        //        .Sort(Builders<UserEntity>.Sort.Ascending("CreatedDate"))
        //        .Limit(10).ToListAsync();

        //    return recentUsers;
        //}

        [Route("api/Users")]
        public HttpResponseMessage Users(HttpRequestMessage request)
        {
            return CaptureResponseMessage(request, () =>
            {
                HttpResponseMessage response = null;
                var users = _userRepository.Get("Users").Find(new BsonDocument())
                    .Sort(Builders<UserEntity>.Sort.Ascending("CreatedDate"))
                    .Limit(10).ToList();
                response = request.CreateResponse(HttpStatusCode.Created, users);
                return response;
            });
        }

       
        [Route("api/User")]
        public HttpResponseMessage GetUser(HttpRequestMessage request)
        {
            return CaptureResponseMessage(request, () =>
            {
                HttpResponseMessage responseMessage = null;
                responseMessage = request.CreateErrorResponse(HttpStatusCode.BadGateway, "No Accsess");
                int i = 10;
                int j = 0;
                int result = i/j;
                return responseMessage;
            });
        }


        [Route("api/AddUser")]
        [HttpPost]
        public HttpResponseMessage Add(HttpRequestMessage request, [FromBody] UserEntity userEntity)
        {
            return CaptureResponseMessage(request, () =>
            {
                HttpResponseMessage response = null;
              //  var userEntity = new UserEntity { FirstName = "Test_FirstName1", LastName = "Test_LaststName1" };
                _userRepository.Add(userEntity, "Users");
                response = request.CreateResponse(HttpStatusCode.OK, userEntity);

                return response;
            });
        }

        // PUT: api/Error/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Error/5
        public void Delete(int id)
        {
        }
    }
}
