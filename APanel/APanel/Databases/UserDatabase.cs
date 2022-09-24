using APanel.Authentication;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace APanel.Databases
{
    internal class UserDatabase : Database, IUserDatabase
    {
        public bool AuthenticateUser(NetworkCredential credentials)
        {
            if (!Connect())
            {
                return false;
            }

            MySqlCommand command = new()
            {
                Connection = Connection,
                CommandText = "SELECT * FROM users WHERE username=@username AND password=@password"
            };

            command.Parameters.Add(new MySqlParameter("@username", credentials.UserName));
            command.Parameters.Add(new MySqlParameter("@password", credentials.Password));

            if (command.ExecuteScalar() is null)
            {
                //- Do smth.

                Disconnect();

                return false;
            }

            Disconnect();

            return true;
        }

        public void Add(User user)
        {
            if (!Connect())
            {
                return;
            }

            MySqlCommand command = new()
            {
                Connection = Connection,
                CommandText = "SELECT * FROM users WHERE username=@username AND email=@email"
            };

            command.Parameters.Add(new MySqlParameter("@username", user.Username));
            command.Parameters.Add(new MySqlParameter("@email", user.Email));
            command.Parameters.Add(new MySqlParameter("@password", user.Password));

            if (command.ExecuteScalar() is not null)
            {
                MessageBox.Show("Registration Error", "User already exist in the database!", MessageBoxButton.OK, MessageBoxImage.Error);

                Disconnect();

                return;
            }

            command.CommandText = "INSERT INTO users (username, email, password) VALUES(@username, @email, @password)";

            command.ExecuteNonQuery();

            Disconnect();
        }

        public void Edit(User user)
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int id)
        {
            if (!Connect())
            {
                return;
            }

            MySqlCommand command = new MySqlCommand()
            {
                Connection = Connection,
                CommandText = "DELETE FROM users WHERE id=@id"
            };

            command.Parameters.Add(new MySqlParameter("@id", id));

            command.ExecuteNonQuery();

            Disconnect();
        }

        public void RemoveByUsername(string username)
        {
            if (!Connect())
            {
                return;
            }

            MySqlCommand command = new MySqlCommand()
            {
                Connection = Connection,
                CommandText = "DELETE FROM users WHERE username=@username"
            };

            command.Parameters.Add(new MySqlParameter("@username", username));

            command.ExecuteNonQuery();

            Disconnect();
        }

        public void RemoveByEmail(string email)
        {
            if (!Connect())
            {
                return;
            }

            MySqlCommand command = new MySqlCommand()
            {
                Connection = Connection,
                CommandText = "DELETE FROM users WHERE email=@email"
            };

            command.Parameters.Add(new MySqlParameter("@email", email));

            command.ExecuteNonQuery();

            Disconnect();
        }

        public User GetById(int id)
        {
            if (!Connect())
            {
                return null;
            }

            MySqlCommand command = new MySqlCommand()
            {
                Connection = Connection,
                CommandText = "SELECT * FROM users WHERE id=@id"
            };

            command.Parameters.Add(new MySqlParameter("@id", id));

            MySqlDataReader reader = command.ExecuteReader();
            User user = null;

            if (reader.Read())
            {
                user = new User(reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
            }

            if (user is null)
            {
                Disconnect();

                return null;
            }

            Disconnect();

            return user;
        }

        public User GetByUsername(string username)
        {
            if (!Connect())
            {
                return null;
            }

            MySqlCommand command = new MySqlCommand()
            {
                Connection = Connection,
                CommandText = "SELECT * FROM users WHERE username=@username"
            };

            command.Parameters.Add(new MySqlParameter("@username", username));

            MySqlDataReader reader = command.ExecuteReader();
            User user = null;

            if (reader.Read())
            {
                user = new User(reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
            }

            if (user is null)
            {
                Disconnect();

                return null;
            }

            Disconnect();

            return user;
        }

        public User GetByEmail(string email)
        {
            if (!Connect())
            {
                return null;
            }

            MySqlCommand command = new MySqlCommand()
            {
                Connection = Connection,
                CommandText = "SELECT * FROM users WHERE email=@email"
            };

            command.Parameters.Add(new MySqlParameter("@email", email));

            MySqlDataReader reader = command.ExecuteReader();
            User user = null;

            if (reader.Read())
            {
                user = new User(reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
            }

            if (user is null)
            {
                Disconnect();

                return null;
            }

            Disconnect();

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            if (!Connect())
            {
                return null;
            }

            MySqlCommand command = new MySqlCommand()
            {
                Connection = Connection,
                CommandText = "SELECT * FROM users"
            };

            MySqlDataReader reader = command.ExecuteReader();
            List<User> users = new List<User>();

            while (reader.Read())
            {
                users.Add(new User(reader[2].ToString(), reader[3].ToString(), reader[4].ToString()));
            }

            if (users.Count == 0)
            {
                Disconnect();

                return null;
            }

            Disconnect();

            return users;
        }
    }
}
