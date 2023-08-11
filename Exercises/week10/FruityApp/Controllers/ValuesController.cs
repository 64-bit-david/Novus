using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;
using FruityApp.Controllers;

namespace FruityApp.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        List<string> fruitList = new List<string>();

        public ValuesController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Read fruit data from file
                string filepath = @"C:\Users\david\Desktop\Capita\CODE2\Code\Novus\Exercises\week10\FruityApp\FruitFile.txt";
                string text = System.IO.File.ReadAllText(filepath);

                // Populate fruitList with data from the file
                foreach (string line in text.Split(","))
                {
                    fruitList.Add(line);
                }

                _logger.LogInformation("Get performed successfully!!");
                return Ok(fruitList); // Return the fruit list
            }
            catch (Exception ex)
            {
                // Log the error and return an internal server error response
                _logger.LogError($"An error occurred: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult PostValue([FromBody] string? value)
        {
            try
            {
                // Validate input value
                if (string.IsNullOrWhiteSpace(value))
                {
                    _logger.LogError("Bad data, action unsuccessful");
                    return BadRequest("Invalid input data"); // Return a bad request response
                }

                // Append the value to the file
                string filepath = @"C:\Users\david\Desktop\Capita\CODE2\Code\Novus\Exercises\week10\FruityApp\FruitFile.txt";
                string text = System.IO.File.ReadAllText(filepath);
                string totalText = (string)text + "," + value;
                System.IO.File.WriteAllText(filepath, totalText);

                // Update fruitList with the new value
                foreach (string line in totalText.Split(","))
                {
                    fruitList.Add(line);
                }

                _logger.LogInformation($"Added successfully: value: {value}");
                return Ok("Added successfully."); // Return success response
            }
            catch (Exception ex)
            {
                // Log the error and return an internal server error response
                _logger.LogError($"An error occurred: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
