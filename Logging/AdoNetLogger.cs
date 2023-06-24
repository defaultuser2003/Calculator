using System;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.SqlClient;

namespace Logging
{
    [Export(typeof(ILogger))]
    public class AdoNetLogger : ILogger
    {
        private string connectionString;

        public AdoNetLogger(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Log(string message)
        {
            string query = "INSERT INTO Logs (Message, Date) VALUES (@Message, @Date)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@Message", SqlDbType.NVarChar).Value = message;
                command.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.Now;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
