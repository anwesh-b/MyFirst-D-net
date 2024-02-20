using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFirst.Model;

namespace MyFirst.Controllers
{
    public class ErrorController(ILogger<ErrorController> logger) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("Error")]
        public ErrorResponseHandler Errorhandler() { 
            logger.LogError("Error aayo");

            return new ErrorResponseHandler
            {
                StatusCode = 500,
                StatusMessage = "Error aayo sedd."
                // message: "Some message"
            };
        }
    }
}
