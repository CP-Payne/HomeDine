using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HomeDine.Api.Controllers
{
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            return Ok();

            // var (statusCode, message) = exception switch
            // {
            //     IServiceException serviceException => (
            //         (int)serviceException.StatusCode,
            //         serviceException.ErrorMessage
            //     ),
            //     _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred."),
            // };
            // return Problem(statusCode: statusCode, title: message);
        }
    }
}
