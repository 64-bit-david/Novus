namespace CalculatorAPI
{


    /// <summary>
    /// Represents a diagnostics interface for logging messages.
    /// </summary>
    public interface IDiagnostics
    {
        void Log(string message);
    }
}
