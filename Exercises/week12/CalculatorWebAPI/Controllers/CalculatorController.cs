using CalculatorAPI;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorWebAPI.Controllers
{
    [ApiController]
    [Route("api/calculator")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculator _calculator;

        public CalculatorController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet("add/{num1}/{num2}")]
        public IActionResult Add(int num1, int num2)
        {
            int result = _calculator.Add(num1, num2);
            return Ok(result);
        }

        // Define other calculator operations as similar methods
    }

}
