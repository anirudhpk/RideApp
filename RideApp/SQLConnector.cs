using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
//using Microsoft.Data.SqlClient;


namespace RideApp
{
    public class SQLConnector
    {
        public static void InsertData(string phoneNo)
        {
            //    try
            //    {
            //        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //        builder.DataSource = "ridedbserver.database.windows.net";
            //        builder.UserID = "ridemaster";
            //        builder.Password = "Anir#0027";
            //        builder.InitialCatalog = "Ride";
            //        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            //        {
            //            String sql = "insert into [dbo].[userdetails](phoneno) values('9884391041')";

            //            using (SqlCommand command = new SqlCommand(sql, connection))
            //            {
            //                connection.Open();
            //                int rowsAffected = command.ExecuteNonQuery();
            //                connection.Close();

            //            }
            //        }
            //    }
            //    catch (SqlException e)
            //    {
            //        Console.WriteLine(e.ToString());
            //    }
            //}
            try
            {
                var builder = new SqlConnection("Server=tcp:ridedbserver.database.windows.net,1433;Initial Catalog=Ride;Persist Security Info=False;User ID=ridemaster;Password=Anir#0027;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                builder.Open();
                //builder.ConnectionString = 
                //    "Data Source=ridedbserver.database.windows.net;"+                    
                //    "Initial Catalog=Ride;" +
                //    "User id=ridemaster;" +
                //    "Password=Anir#0027;";
                // builder.DataSource = "ridedbserver.database.windows.net";
                // builder.UserID = "ridemaster";
                // builder.Password = "Anir#0027";
                // builder.InitialCatalog = "Ride";                
                //using (SqlConnection connection = new SqlConnection(builder.ConnectionString))

                String sql = "insert into [dbo].[userdetails](phoneno) values('9884391041')";

                using (SqlCommand command = new SqlCommand(sql, builder))
                {
                    //connection.Open();
                    
                    int rowsAffected = command.ExecuteNonQuery();
                    builder.Close();

                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }    
}

