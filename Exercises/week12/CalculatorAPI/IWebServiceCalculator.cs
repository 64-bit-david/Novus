using System.Net.Http;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    /// <summary>
    /// Represents a calculator that performs calculations using a web service
    /// </summary>
    public interface IWebServiceCalculator
    {
        /// <summary>
        /// Performs an asynchronous addition operation using the specified <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> used to make the HTTP request.</param>
        /// <param name="num1">The first number to add.</param>
        /// <param name="num2">The second number to add.</param>
        /// <returns>The result of the addition operation.</returns>
        Task<int> AsyncAdd(HttpClient httpClient, int num1, int num2);


        /// <summary>
        /// Performs an asynchronous subtraction operation using the specified <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> used to make the HTTP request.</param>
        /// <param name="num1">The number to subtract from.</param>
        /// <param name="num2">The number to subtract.</param>
        /// <returns>The result of the subtraction operation.</returns>
        Task<int> AsyncSubtract(HttpClient httpClient, int num1, int num2);



        /// <summary>
        /// Performs an asynchronous subtraction operation using the specified <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> used to make the HTTP request.</param>
        /// <param name="num1">The number to subtract from.</param>
        /// <param name="num2">The number to subtract.</param>
        /// <returns>The result of the subtraction operation.</returns>
        Task<int> AsyncMultiply(HttpClient httpClient, int num1, int num2);


        /// <summary>
        /// Performs an asynchronous subtraction operation using the specified <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> used to make the HTTP request.</param>
        /// <param name="num1">The number to subtract from.</param>
        /// <param name="num2">The number to subtract.</param>
        /// <returns>The result of the subtraction operation.</returns>
        Task<int> AsyncDivide(HttpClient httpClient, int num1, int num2);
    }
}
