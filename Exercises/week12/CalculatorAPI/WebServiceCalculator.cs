using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        public async Task<int> Add(HttpClient httpClient, int num1, int num2)
        {
            string url = $"{CalcApiUrl}/api/calculator/add/{num1}/{num2}";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                int result = int.Parse(res);
                return result;
            }
            else
            {
                throw new HttpRequestException($"HTTP request failed with status code: {response.StatusCode}");
            }
        }

        ///<inheritdoc/>
        public async Task<int> Subtract(HttpClient httpClient, int num1, int num2)
        {
            string url = $"{CalcApiUrl}/api/calculator/subtract/{num1}/{num2}";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                int result = int.Parse(res);
                return result;
            }
            else
            {
                throw new HttpRequestException($"HTTP request failed with status code: {response.StatusCode}");
            }
        }

        ///<inheritdoc/>
        public async Task<int> Multiply(HttpClient httpClient, int num1, int num2)
        {
            string url = $"{CalcApiUrl}/api/calculator/multiply/{num1}/{num2}";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                int result = int.Parse(res);
                return result;
            }
            else
            {
                throw new HttpRequestException($"HTTP request failed with status code: {response.StatusCode}");
            }
        }

        ///<inheritdoc/>
        public async Task<int> Divide(HttpClient httpClient, int num1, int num2)
        {
            string url = $"{CalcApiUrl}/api/calculator/divide/{num1}/{num2}";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                int result = int.Parse(res);
                return result;
            }
            else
            {
                throw new HttpRequestException($"HTTP request failed with status code: {response.StatusCode}");
            }
        }
    }
}
