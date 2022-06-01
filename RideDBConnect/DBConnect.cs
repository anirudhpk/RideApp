using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace RideDBConnect
{
    public class DBConnect
    {
        public static void InsertData(string phoneNo)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "ridedbserver.database.windows.net";
                builder.UserID = "ridemaster";
                builder.Password = "Anir#0027";
                builder.InitialCatalog = "Ride";
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String sql = "insert into [dbo].[userdetails](phoneno) values('9884391041')";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
