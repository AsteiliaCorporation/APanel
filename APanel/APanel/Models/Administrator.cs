using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APanel.Authentication
{
    internal class Administrator : User
    {
        public Administrator(string username, string password, string email)
            : base(username, password, email)
        {

        }
    }
}
