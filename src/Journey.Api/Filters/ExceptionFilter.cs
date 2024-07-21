using Journey.Communication.Responses;
using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Journey.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException)
            {
                var journeyException = (JourneyException)context.Exception;

                context.HttpContext.Response.StatusCode = (int)journeyException.GetStatusCode();

                var responseJson = new ResponseErrorsJson(journeyException.GetErrorMessage());

                context.Result = new ObjectResult(responseJson);
            }
            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var list = new List<string>
                {
                    "Erro Desconhecido"
                };

                var responseJson = new ResponseErrorsJson(list);
                
                context.Result = new ObjectResult(responseJson);
            }
        }
    }
}
