using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace APanel.Authentication
{
    internal static class Authenticate
    {
        public static void Login(User user)
        {
            MessageBox.Show(user.Username);
            MessageBox.Show(user.Password);
            MessageBox.Show(user.Email);

            if (false) //- Check if user exists in the database!
            {
                throw new ArgumentNullException("User does NOT exist in the database!");
            }

            if (true)
            {

            }
        }

        public static void Logout(User user)
        {

        }

        public static void Register(User user)
        {

        }
    }
}
