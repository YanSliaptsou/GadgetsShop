using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace GadgetsShop
{
    /// <summary>
    /// This class provides an access to the database
    /// </summary>
    public class SqlWorker
    {
        //Connection string
        private string connectionString;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userConnectionString">Connection string to the database</param>
        public SqlWorker(string userConnectionString)
        {
            this.connectionString = userConnectionString;
        }
        /// <summary>
        /// This method selects data from database.
        /// </summary>
        /// <param name="query">User's query</param>
        /// <returns>A string with data</returns>
        public string SelectDataFromDB(string query)
        {
            string data = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        data = reader.GetValue(0) + "";
                    }
                    reader.Close();
                }
            }
            return data;
        }
    }
}
