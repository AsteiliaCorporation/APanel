using APanel.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APanel.Databases
{
    internal interface IUserDatabase
    {
        bool AuthenticateUser(NetworkCredential credentials);

        void Add(User user);

        void Edit(User user);

        void RemoveById(int id);

        void RemoveByUsername(string username);

        void RemoveByEmail(string email);

        User GetById(int id);

        User GetByUsername(string username);

        User GetByEmail(string email);

        IEnumerable<User> GetAll();
    }
}
