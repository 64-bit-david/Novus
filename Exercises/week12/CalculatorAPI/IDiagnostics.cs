using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    public interface IDiagnostics
    {
        void Log(string message);
    }
}
