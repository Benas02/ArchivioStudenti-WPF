using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.Model;

namespace WPFDemo.Controller
{
    internal static class CorsiController
    {
        private static string connectionString = "Data Source=(local); Initial Catalog=Studenti; Integrated Security=True";

        #region "Get All Corsi"
        public static async Task<List<Corso>> GetAllCorsi()
        {
            List<Corso> courses = new List<Corso>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    string queryString = "SELECT * FROM Corsi";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        Corso corso = new Corso
                        {
                            IdCorso = (int)reader["IdCorso"],
                            Nome = (string)reader["Nome"]
                        };

                        courses.Add(corso);
                    }

                    return courses;
                } catch (Exception ex)
                {
                    return null;
                }                
            }
        }
        #endregion
    }
}
