using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    /// <summary>
    /// Provides extension methods for working with <see cref="HttpContent"/>.
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Reads the content of the HTTP response as a string and parses it into an integer.
        /// </summary>
        /// <param name="content">The HTTP response content to read.</param>
        /// <returns>The parsed integer value from the response content.</returns>
        public static async Task<int> ReadAsAsyncInt(this HttpContent content)
        {
            string responseContent = await content.ReadAsStringAsync();
            if (int.TryParse(responseContent, out int result))
            {
                return result;
            }
            else
            {
                throw new InvalidOperationException("Invalid response format.");
            }
        }
    }
}
