using System;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        string connectionString = "your_connection_string_here";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM Employees";             SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            string jsonReport = JsonConvert.SerializeObject(dt, Formatting.Indented);
            Console.WriteLine("\nJSON Report:\n" + jsonReport);
        }
    }
}

