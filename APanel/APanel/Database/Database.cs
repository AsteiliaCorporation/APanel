using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace APanel.Database
{
    internal class Database
    {
        private MySqlConnection _connection;

        private string _server = "localhost";
        private string _database = "apanel";
        private string _username = "root";
        private string _password = "";
        
        public Database()
        {
            _connection = new MySqlConnection($"SERVER={_server};DATABASE={_database};UID={_username};PASSWORD={_password};");
        }

        public bool Connect()
        {
            try
            {
                _connection.Open();

                return true;
            }
            catch (MySqlException exception)
            {
                switch (exception.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }

                return false;
            }
        }

        private bool Disconnect()
        {
            try
            {
                _connection.Close();

                return true;
            }
            catch (MySqlException exception)
            {
                MessageBox.Show(exception.Message);

                return false;
            }
        }

        public void Insert()
        {
            string query = $"INSERT INTO users (username, password) VALUES('Suat Alikoch', '17')";

            if (Connect())
            {
                MySqlCommand command = new MySqlCommand(query, _connection);

                command.ExecuteNonQuery();
                Disconnect();
            }
        }

        public void Update()
        {
            string query = $"UPDATE users SET username='Anton Dimitrov', age='16' WHERE name='Suat Alikoch'";

            if (Connect())
            {
                MySqlCommand command = new MySqlCommand(query, _connection);

                command.ExecuteNonQuery();
                Disconnect();
            }
        }

        public void Delete()
        {
            string query = $"DELETE FROM users WHERE name='Suat Alikoch'";

            if (Connect())
            {
                MySqlCommand command = new MySqlCommand(query, _connection);

                command.ExecuteNonQuery();
                Disconnect();
            }
        }

        public List<string>[]? Select()
        {
            return default;
        }

        public int Count()
        {
            return default;
        }

        public void Backup()
        {

        }

        public void Restore()
        {

        }
    }
}
