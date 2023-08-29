using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    /// <summary>
    /// Implements the <see cref="IDiagnostics"/> interface by logging messages to a database.
    /// </summary>
    public class DbDiagnostics : IDiagnostics
    {

        private readonly CalcDiagnosticsEntities1 _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbDiagnostics"/> class with the provided database context.
        /// </summary>
        /// <param name="context">The database context used for logging.</param>
        public DbDiagnostics(CalcDiagnosticsEntities1 context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        /// <summary>
        /// Logs a message to the database with the current timestamp and information type.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        public void Log(string message)
        {
            //create a new log entry
            var logEntry = new Log
            {
                Timestamp = DateTime.Now,
                MessageType = "Information", 
                Message = message
            };

            // Add the log entry to the context and save changes to the database
            _context.Logs.Add(logEntry);
            _context.SaveChanges();
        }
    }
}
