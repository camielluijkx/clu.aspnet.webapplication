using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class SqlInjectionController : Controller
    {
        private string _connectionString = @"(local)\etc.";

        public IActionResult GetUserUnsafe(string id) // SQL Injection Susceptible Action
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(string.Format("SELECT * FROM Users WHERE ID = {0}", id), connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        string result = "";

                        while (reader.Read())
                        {
                            result = (string)reader["UserName"];
                        }

                        return View("GetUser", result);
                    }
                }
            }

            /*
            
            Malicious Input for SQL Injection:

                1; DROP TABLE USERS;
            
            */
        }

        public IActionResult GetUserSafe(string id) // Parameterized Queries
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(string.Format("SELECT * FROM Users WHERE ID = @id", id), connection))
                {
                    command.Parameters.AddWithValue("id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        string result = "";

                        while (reader.Read())
                        {
                            result = (string)reader["UserName"];
                        }

                        return View("GetUser", result);
                    }
                }
            }
        }
    }
}