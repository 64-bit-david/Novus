using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAPI
{

    /// <summary>
    /// Represents a calculator that performs basic arithmetic operations.
    /// </summary>
    /// 
    public class Calculator: ICalculator
    {
        private readonly IDiagnostics diagnostics = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="Calculator"/> class with a diagnostics logger.
        /// </summary>
        /// <param name="diagnostics">The diagnostics logger.</param>
        public Calculator(IDiagnostics diagnostics)
        {
            diagnostics = diagnostics ?? throw new ArgumentNullException(nameof(diagnostics));
        }

       
        
        /// <inheritdoc />
        public int Add(int start, int by){  return start + by;    }


        /// <inheritdoc />
        public int Subtract(int start, int by) { return start - by; }


        /// <inheritdoc />
        public int Multiply(int start, int by) { return start * by; }


        /// <inheritdoc />
        public int Divide(int start, int by) { return start / by; }
    }
}
