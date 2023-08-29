using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculatorAPI
{

    public static class HttpClientExtensions
    {
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
