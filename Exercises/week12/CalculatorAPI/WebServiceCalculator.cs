using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    /// <summary>
    /// Implements the <see cref="IWebServiceCalculator"/> interface by making HTTP requests to a calculator web service.
    /// </summary>
    public class WebServiceCalculator : IWebServiceCalculator
    {
        private const string CalcApiUrl = "http://localhost:5110";

        private static readonly HttpClient client = new HttpClient();

        /// <inheritdoc/>
        public async Task<int> AsyncAdd(HttpClient httpClient, int num1, int num2)
        {
            string url = $"{CalcApiUrl}/api/calculator/add/{num1}/{num2}";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                int result = await response.Content.ReadAsAsyncInt();
                return result;
            }
            else
            {
                throw new HttpRequestException($"HTTP request failed with status code: {response.StatusCode}");
            }
        }

        ///<inheritdoc/>
        public async Task<int> AsyncSubtract(HttpClient httpClient, int num1, int num2)
        {
            string url = $"{CalcApiUrl}/api/calculator/subtract/{num1}/{num2}";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                int result = await response.Content.ReadAsAsyncInt();
                return result;
            }
            else
            {
                throw new HttpRequestException($"HTTP request failed with status code: {response.StatusCode}");
            }
        }

        ///<inheritdoc/>
        public async Task<int> AsyncMultiply(HttpClient httpClient, int num1, int num2)
        {
            string url = $"{CalcApiUrl}/api/calculator/multiply/{num1}/{num2}";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                int result = await response.Content.ReadAsAsyncInt();
                return result;
            }
            else
            {
                throw new HttpRequestException($"HTTP request failed with status code: {response.StatusCode}");
            }
        }

        ///<inheritdoc/>
        public async Task<int> AsyncDivide(HttpClient httpClient, int num1, int num2)
        {
            string url = $"{CalcApiUrl}/api/calculator/divide/{num1}/{num2}";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                int result = await response.Content.ReadAsAsyncInt();
                return result;
            }
            else
            {
                throw new HttpRequestException($"HTTP request failed with status code: {response.StatusCode}");
            }
        }
    }
}
