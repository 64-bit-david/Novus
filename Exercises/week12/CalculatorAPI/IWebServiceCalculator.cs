using System.Net.Http;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    public interface IWebServiceCalculator
    {
        Task<int> AsyncAdd(HttpClient httpClient, int num1, int num2);
        Task<int> AsyncSubtract(HttpClient httpClient, int num1, int num2);
        Task<int> AsyncMultiply(HttpClient httpClient, int num1, int num2);
        Task<int> AsyncDivide(HttpClient httpClient, int num1, int num2);
    }
}
