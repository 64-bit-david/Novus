using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    public class Calculator: ICalculator
    {
        private readonly IDiagnostics diagnostics = null;

        public Calculator(IDiagnostics diagnostics)
        {
            diagnostics = diagnostics ?? throw new ArgumentNullException(nameof(diagnostics));
        }
        public int Add(int start, int by){  return start + by;    }

        public int Subtract(int start, int by) { return start - by; }

        public int Multiply(int start, int by) { return start * by; }

        public int Divide(int start, int by) { return start / by; }
    }
}
