using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace APanel.Databases
{
    internal abstract class Database
    {
        private MySqlConnection _connection;

        private string _server = "localhost";
        private string _database = "apanel";
        private string _username = "root";
        private string _password = "";

        public Database()
        {
            Connection = new MySqlConnection($"SERVER={_server};DATABASE={_database};UID={_username};PASSWORD={_password};SSLMODE=Preferred");
        }

        protected bool Connect()
        {
            try
            {
                Connection.Open();

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
                    default:
                        MessageBox.Show("Unknown error!");
                        break;
                }

                return false;
            }
        }

        protected bool Disconnect()
        {
            try
            {
                Connection.Close();

                return true;
            }
            catch (MySqlException exception)
            {
                MessageBox.Show(exception.Message);

                return false;
            }
        }

        public void Insert(string table, string specificTables, string values)
        {
            string query = $"INSERT INTO {table} ({specificTables}) VALUES({values})";

            if (Connect())
            {
                MySqlCommand command = new MySqlCommand(query, Connection);

            command.ExecuteNonQuery();
                Disconnect();
            }
        }

        public void Update()
        {
            string query = $"UPDATE users SET username='Anton Dimitrov', age='16' WHERE name='Suat Alikoch'";

            if (Connect())
            {
                MySqlCommand command = new MySqlCommand(query, Connection);

                command.ExecuteNonQuery();
                Disconnect();
            }
        }

        public void Delete()
        {
            string query = $"DELETE FROM users WHERE name='Suat Alikoch'";

            if (Connect())
            {
                MySqlCommand command = new MySqlCommand(query, Connection);

                command.ExecuteNonQuery();
                Disconnect();
            }
        }

        public bool Select(string table, string columnItem, string value, string columnItem2, string value2)
        {
            string query = $"SELECT * FROM {table} WHERE {columnItem}='{value}' AND {columnItem2}='{value2}'";

            List<string> result = new List<string>();

            if (Connect())
            {
                MySqlCommand command = new MySqlCommand(query, Connection);

                if (command.ExecuteScalar() == null)
                {
                    return false;
                }

                Disconnect();
            }

            return true;
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

        protected MySqlConnection Connection 
        { 
            get => _connection;
            private set => _connection = value; 
        }
    }
}
