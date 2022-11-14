using AdpWebLabs.Api.Controllers.Custom;
using AdpWebLabs.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdpWebLabs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : CustomReturnController
    {
        private readonly ICalculationService _calculationService;
        private readonly ILogger<CalculationController> _logger;

        public CalculationController(ICalculationService calculationService, ILogger<CalculationController> logger)
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
                return ResultHandler(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResultHandler(ex);
            }
        }
    }
}
