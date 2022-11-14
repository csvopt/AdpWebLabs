using Microsoft.AspNetCore.Mvc;

namespace AdpWebLabs.Api.Controllers.Custom
{
    public class CustomReturnController : ControllerBase
    {
        protected IActionResult ResultHandler(int statusCode, object? result = null) => StatusCode(statusCode, result);

        protected IActionResult ResultHandler(Exception ex) => StatusCode(StatusCodes.Status500InternalServerError, ex);
    }
}
