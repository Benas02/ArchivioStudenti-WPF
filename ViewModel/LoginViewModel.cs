using System;
using System.Data;
using System.Data.SqlClient;
using WPFDemo.Model;
using WPFDemo.View;

namespace WPFDemo.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        #region "Username"
        // Declare a private field to store the _username as a string
        private string _username;

        // Create a public property named username, which allows access to _username
        public string username
        {
			get { return _username; }
            // When the value of username is set, update the private field and raise the PropertyChanged event
            set { 
                _username = value; 
                propertyChanged("username"); 
                propertyChanged("canLogin");

                ClearErrors("username");
                if (string.IsNullOrEmpty(value))
                {
                    addErrors("username", "Campo Obbligatorio");
                }
            }
		}
        #endregion

        #region "Password"
        // Declare a private field to store the _password as a string
        private string _password;

        // Create a public property named password, which allows access to _password
        public string password
        {
			get { return _password; }
            // When the value of password is set, update the private field and raise the PropertyChanged event
            set { _password = value; propertyChanged("password"); propertyChanged("canLogin"); }
		}
        #endregion

        #region "Risultato"
        // Declare a private field to store the _risultato as a string
        private string _risultato = "Risultato Login";

        // Create a public property named risultato, which allows access to _risultato
        public string risultato
		{
			get { return _risultato; }
            // When the value of risultato is set, update the private field and raise the PropertyChanged event
            set { _risultato = value; propertyChanged("risultato"); }
		}
        #endregion

        #region "Can Login"
        public bool canLogin
        {
            get { return !(string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)); }
        }
        #endregion

// -------------------------------------------------------------------------------------------------------------------

        #region "Login"
        public bool Login()
        {
            // Connection string to the database
            string connectionString = "Data Source=(local); Initial Catalog=Studenti; Integrated Security=True";

            // Establish a database connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Construct the initial SQL query
                    string queryString = $"SELECT * FROM Users";

                    // If both username and password are provided, extend the query to filter by username and password
                    if ((username != "") && (password != ""))
                    {
                        // Define the SQL query to retrieve data from the "clienti" table
                        queryString += $" WHERE Users.Username = @Username AND Users.Password = @Password";
                    }

                    // Create an SQL command
                    SqlCommand command = new SqlCommand(queryString, connection);

                    // Add parameters for username and password to the SQL command
                    command.Parameters.AddWithValue("Username", username);
                    command.Parameters.AddWithValue("Password", password);

                    // Execute the SQL query and get the results
                    SqlDataReader reader = command.ExecuteReader();

                    // Handle the results
                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    {
                        // If username or password is empty, set the result message
                        risultato = "Username o Password Vuoti";
                        return false;
                    }
                    else if (reader.Read())
                    {
                        // If a matching user is found, create a user object and set the welcome message
                        User user = new User
                        {
                            Username = (string)reader["Username"],
                            Password = (string)reader["Password"],
                            FullName = (string)reader["FullName"]
                        };

                        risultato = $"Benvenuto {user.FullName}";
                        return true;
                    }
                    else
                    {
                        // If no matching user is found, set an error message
                        risultato = "Username o Password Errati";
                        return false;
                    }

                    // Close the database connection
                    // connection.Close();y
                } 
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        #endregion

    }
}
