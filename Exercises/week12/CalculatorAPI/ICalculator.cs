using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    public interface ICalculator
    {
        int Add(int start, int by);
        int Subtract(int start, int by);
        int Multiply(int start, int by);
        int Divide(int start, int by);

    }
}
