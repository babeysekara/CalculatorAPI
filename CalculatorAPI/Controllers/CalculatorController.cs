using Microsoft.AspNetCore.Mvc;
using CalculatorAPI.Models;
using CalculatorAPI.Services;

namespace CalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] CalculatorRequest request)
        {
            try
            {
                var result = _calculatorService.Calculate(request);
                return Ok(result);
            }
            catch (DivideByZeroException ex)
            {
                return BadRequest(new CalculatorResponse { Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new CalculatorResponse { Message = ex.Message });
            }
        }
    }
}
