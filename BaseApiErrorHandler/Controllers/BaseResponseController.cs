using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiErrorHandler.Models;
using ApiErrorHandler.Repository;

namespace ApiErrorHandler.Controllers
{
    /// <summary>
    /// BaseClass for Api controller to facilitate the exception at one place
    /// </summary>
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

        /// <summary>
        ///  base class method to capture the response message
        /// </summary>
        /// <param name="request"></param>
        /// <param name="errorFunc"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method to log the exception message
        /// </summary>
        /// <param name="exception"></param>
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
