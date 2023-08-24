using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    public class DbDiagnostics : IDiagnostics
    {

        private readonly CalcDiagnosticsEntities1 _context;

        public DbDiagnostics(CalcDiagnosticsEntities1 context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Log(string message)
        {
            var logEntry = new Log
            {
                Timestamp = DateTime.Now,
                MessageType = "Information", // Set the appropriate message type
                Message = message
            };

            _context.Logs.Add(logEntry);
            _context.SaveChanges();
        }
    }
}
