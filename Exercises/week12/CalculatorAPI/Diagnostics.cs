using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAPI
{

    /// <summary>
    /// Implements the <see cref="IDiagnostics"/> interface by logging messages to the console.
    /// </summary>
    public class Diagnostics : IDiagnostics
    {
        public void Log(string message)
        {
            Console.WriteLine($"");
        }
    }
}
