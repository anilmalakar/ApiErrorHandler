using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiErrorHandler.Models;
using ApiErrorHandler.Repository;

namespace ApiErrorHandler.Controllers
{
    public class BaseResponseController : ApiController
    {
        protected readonly IBaseRepository<ErrorEntity> _repository;

        public BaseResponseController(IBaseRepository<ErrorEntity> repository)
        {
            _repository = repository;
        }

        public BaseResponseController()
        {
            _repository = new BaseRepository<ErrorEntity>();
        }

      protected HttpResponseMessage CaptureResponseMessage(HttpRequestMessage request, Func<HttpResponseMessage> errorFunc)
        {
            HttpResponseMessage errorResponseMessage = null;

            try
            {
                errorResponseMessage = errorFunc.Invoke();
            }
            catch (Exception ex)
            {
                LogErrorMessage(ex);
                errorResponseMessage = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return errorResponseMessage;
        }

        private void LogErrorMessage(Exception exception)
        {
            var err = new ErrorEntity
            {
                ErrorMessage = exception.Message,
                ErrorType = exception.GetType().ToString(),
                StackTrace = exception.StackTrace
            };
            _repository.Add(err, "Errors");
        }
    }
}
