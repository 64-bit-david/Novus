using CalculatorAPI; // Make sure to include the appropriate namespace
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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

        /// <summary>
        /// Adds two numbers.
        /// </summary>
        /// <param name="num1">The first number.</param>
        /// <param name="num2">The second number.</param>
        /// <returns>The result of the addition.</returns>
        [HttpGet("add/{num1}/{num2}")]
        public IActionResult Add(int num1, int num2)
        {
            try
            {
                int result = _calculator.Add(num1, num2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Subtracts one number from another.
        /// </summary>
        /// <param name="num1">The number to subtract from.</param>
        /// <param name="num2">The number to subtract.</param>
        /// <returns>The result of the subtraction.</returns>
        [HttpGet("subtract/{num1}/{num2}")]
        public IActionResult Subtract(int num1, int num2)
        {
            try
            {
                int result = _calculator.Subtract(num1, num2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Divides one number by another.
        /// </summary>
        /// <param name="num1">The dividend.</param>
        /// <param name="num2">The divisor.</param>
        /// <returns>The result of the division.</returns>
        [HttpGet("divide/{num1}/{num2}")]
        public IActionResult Divide(int num1, int num2)
        {
            try
            {
                int result = _calculator.Divide(num1, num2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Multiplies two numbers.
        /// </summary>
        /// <param name="num1">The first number.</param>
        /// <param name="num2">The second number.</param>
        /// <returns>The result of the multiplication.</returns>
        [HttpGet("multiply/{num1}/{num2}")]
        public IActionResult Multiply(int num1, int num2)
        {
            try
            {
                int result = _calculator.Multiply(num1, num2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}
