using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab5.Database
{
    public class Database
    {
        public static DataTable ReadTable(string storedProcedureName, Dictionary<string, object> para = null)
        {
            try
            {
                // Result variable
                DataTable resultTable = new DataTable();

                // Create connection
                string SQLConnectionString =
                    ConfigurationManager.ConnectionStrings["TESTAPIConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(SQLConnectionString);

                connection.Open();

                // Create and Assign properties for command
                SqlCommand sqlCmd = connection.CreateCommand();
                sqlCmd.Connection = connection;
                sqlCmd.CommandText = storedProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                // Check parameters in Stored Procedure
                if (para != null)
                {
                    foreach (KeyValuePair<string, object> data in para)
                    {
                        if (data.Value == null)
                        {
                            sqlCmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                        }
                        else
                        {
                            sqlCmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                        }
                    }
                }

                // Execute sqlCommand and Assign to result variable
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCmd;
                sqlDA.Fill(resultTable);

                connection.Close();

                return resultTable;
            }
            catch
            {
                return null;
            }
        }
    }
}