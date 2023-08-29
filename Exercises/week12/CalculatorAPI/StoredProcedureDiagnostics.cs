using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    /// <summary>
    /// Implements the <see cref="IDiagnostics"/> interface by logging messages to a database.
    /// </summary>
    public class StoredProcedureDiagnostics : IDiagnostics
    {
        private readonly string _connectionString;


        /// <summary>
        /// Initializes a new instance of the <see cref="StoredProcedureDiagnostics"/> class with the provided connection string.
        /// </summary>
        /// <param name="connectionString">The connection string used to connect to the database.</param>
        public StoredProcedureDiagnostics(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }



        /// <summary>
        /// Logs a message to the database using a stored procedure, including the current timestamp and information type.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        public void Log(string message)
        {

            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("InsertDiagnosticsLogs", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Message", message);
                    cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                    cmd.Parameters.AddWithValue("@MessageType", "Information");

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
