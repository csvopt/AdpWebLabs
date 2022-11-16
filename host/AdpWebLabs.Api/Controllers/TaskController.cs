using AdpWebLabs.Api.Controllers.Custom;
using AdpWebLabs.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdpWebLabs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : CustomReturnController
    {
        private readonly ITaskService _calculationService;
        private readonly ILogger<TaskController> _logger;

        public TaskController(ITaskService calculationService, ILogger<TaskController> logger)
        {
            _calculationService = calculationService;
            _logger = logger;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _calculationService.Calculate();

                var a = ResultHandler(result.Key, result.Value);
                return ResultHandler(result.Key, result.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResultHandler(ex);
            }
        }
    }
}
