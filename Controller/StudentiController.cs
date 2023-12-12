using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Documents;
using WPFDemo.Model;

namespace WPFDemo.Controller
{
    internal static class StudentiController
    {
        private static string connectionString = "Data Source=(local); Initial Catalog=Studenti; Integrated Security=True";

        #region "Studente Random"
        public static async Task<Studente> GetRandomStudent()
        //public static Studente GetRandomStudent()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    //connection.Open();
                    string queryString = "SELECT TOP 1 Studenti.*, Corsi.Nome as NomeCorso " +
                                         "FROM Studenti JOIN Corsi ON Studenti.idCorso = Corsi.IdCorso " +
                                         "ORDER BY NEWID()";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    //SqlDataReader reader = command.ExecuteReader();

                    await reader.ReadAsync();                    
                    //reader.Read();                    
                    return new Studente
                    {
                        IdStudente = (int)reader["IdStudente"],
                        Cognome = (string)reader["Cognome"],
                        Nome = (string)reader["Nome"],
                        DataNascita = (DateTime)reader["DataNascita"],
                        idCorso = (int)reader["idCorso"],
                        Corso = new Corso
                        {
                            IdCorso = (int)reader["IdCorso"],
                            Nome = (string)reader["NomeCorso"]
                        }
                    };                    
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        #endregion

        #region "Get Studenti"
        public static async Task<List<Studente>> GetStudente(string filtro) 
        { 
            List<Studente> studentes = new List<Studente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    string queryString = "SELECT Studenti.*, Corsi.Nome as NomeCorso " +
                                         "FROM Studenti JOIN Corsi ON Studenti.idCorso = Corsi.IdCorso " +
                                         "WHERE Studenti.Nome LIKE @filtro OR Studenti.Cognome LIKE @filtro";

                    //string queryString = "SELECT Studenti.*, Corsi.Nome as NomeCorso " +
                    //                     "FROM Studenti JOIN Corsi ON Studenti.idCorso = Corsi.IdCorso ";

                    SqlCommand command = new SqlCommand(queryString, connection);

                    command.Parameters.AddWithValue("@filtro", $"%{filtro}%");

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while(await reader.ReadAsync())
                    {
                        Studente studente = new Studente
                        {
                            IdStudente = (int)reader["IdStudente"],
                            Cognome = (string)reader["Cognome"],
                            Nome = (string)reader["Nome"],
                            DataNascita = (DateTime)reader["DataNascita"],
                            idCorso = (int)reader["idCorso"],
                            Corso = new Corso
                            {
                                IdCorso = (int)reader["IdCorso"],
                                Nome = (string)reader["NomeCorso"]
                            }
                        };

                        studentes.Add(studente);
                    }

                    /*Predicate<Studente> f_anon = delegate (Studente studente)
                    {
                        return studente.CognomeNome.Contains(filtro);
                    };*/

                    //return studentes.FindAll(s => s.CognomeNome.Contains(filtro));

                    return studentes;
                } catch (Exception ex)
                {
                    return null;
                }
            }
        }
        #endregion

        #region "Elimina Studente"
        public static async Task Delete(int IdStudente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string queryString = "DELETE FROM Studenti WHERE Studenti.IdStudente = @IdStudente";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@IdStudente", IdStudente);
                await command.ExecuteNonQueryAsync();
            }
        }
        #endregion

        #region "Aggiungere Nuovo Studente"
        public static async Task AddStudenteAsync(Studente studente)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string queryString = $"INSERT INTO Studenti (Cognome, Nome, DataNascita, idCorso) VALUES " +
                                     "(@Cognome, @Nome, @DataNascita, @idCorso)";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@Cognome", studente.Cognome);
                command.Parameters.AddWithValue("@Nome", studente.Nome);
                command.Parameters.AddWithValue("@DataNascita", studente.DataNascita);
                command.Parameters.AddWithValue("@idCorso", studente.idCorso);
                await command.ExecuteNonQueryAsync();
            }
        }
        #endregion

        #region "Aggiuornare Uno Studente"
        public static async Task EditStudenteAsync(Studente studente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string queryString = $"UPDATE Studenti " +
                                      "SET Cognome = @Cognome, " +
                                      "Nome = @Nome, " +
                                      "DataNascita = @DataNascita, " + 
                                      "idCorso = @idCorso " +
                                      "WHERE IdStudente = @IdStudente";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@Cognome", studente.Cognome);
                command.Parameters.AddWithValue("@Nome", studente.Nome);
                command.Parameters.AddWithValue("@DataNascita", studente.DataNascita);
                command.Parameters.AddWithValue("@idCorso", studente.idCorso);
                command.Parameters.AddWithValue("@IdStudente", studente.IdStudente);
                await command.ExecuteNonQueryAsync();
            }
        }
        #endregion
    }
}
