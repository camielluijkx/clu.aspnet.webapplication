using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class DatabaseController : Controller
    {
        #region Example #75

        [Route("Database/Index75")]
        public IActionResult Index75() // Connecting to SQL Express Database
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=PhotoSharingDB;Integrated Security=SSPI";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
            }

            return View();
        }

        #endregion

        #region Example #76

        [Route("Database/Index76")]
        public IActionResult Index76() // Connecting to a Microsoft Azure SQL Database
        {
            string connectionString = "Server=tcp:example.database.windows.net,1433;Database=PhotoSharingDB;User ID=Admin@example;Password=Pa$$w0rd;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;PersistSecurityInfo=true";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
            }

            return View();
        }

        #endregion

        #region Example #77

        [Route("Database/Index77")]
        public IActionResult Index77() // Querying a Database with a Data Reader
        {
            List<string> cities = new List<string>();

            string connectionString = "Server=(localdb)\\sqlexpress;Database=MyDB;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("select * from city", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string city = (string)reader["Name"];

                            cities.Add(city);
                        }
                    }
                }
            }

            return View(cities);
        }

        #endregion

        #region Example #78

        [Route("Database/Index78")]
        public IActionResult Index78() // Loading Data into a DataSet Object with the SqlDataAdapter Class
        {
            List<string> cities = new List<string>();

            string connectionString = "Server=(localdb)\\sqlexpress;Database=MyDB;Integrated Security=True;";

            string query = "select * from city";

            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                DataSet dataSet = new DataSet();

                adapter.Fill(dataSet);

                foreach (DataRow row in dataSet.Tables["Table"].Rows)
                {
                    string city = (string)row["name"];

                    cities.Add(city);
                }
            }

            return View(cities);
        }

        #endregion
    }
}