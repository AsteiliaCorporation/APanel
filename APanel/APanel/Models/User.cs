using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APanel.Authentication
{
    internal class User
    {
        private bool _isLoggedIn;
		private string _username;
		private string _password;
		private string _email;
		private string _firstName;
		private string _lastName;
		private string _address;
		private string _phone;
		private string _city;
		private string _state;
		private string _zipcode;
		private string _country;
		private DateTime _registrationDate;
		private DateTime _modificationDate;
		private DateTime _unregistrationDate;

        public User(string username, string password, string email)
        {
            IsLoggedIn = true;
            Username = username;
            Password = password;
            Email = email;
            RegistrationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
        }

        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set { _isLoggedIn = value; }
        }

        public string Username
		{
			get { return _username; }
			set
			{
				if (value.Length < 2 || value.Length > 32)
				{
					throw new ArgumentOutOfRangeException("Username", "Username length must be between 2-32 characters!");
				}

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Username", "Username CANNOT be whitespace!");
                }

				_username = value;
			}
		}

        public string Password
		{
			get { return _password; }
			set
			{
				if (value.Length < 6 || value.Length > 64)
				{
					throw new ArgumentOutOfRangeException("Password", "Password length must be between 6-64 characters!");
				}

				_password = value;
			}
		}

        public string Email
		{
			get { return _email; }
			set
			{
				if (!value.Contains("@"))
				{
                    throw new ArgumentException("Invalid email!");
				}

				_email = value;
			}
		}

        public string FirstName
		{
            get { return _firstName; }
            set
            {
                if (false)
                {
                    throw new ArgumentException("");
                }

                _firstName = value;
            }
        }

        public string LastName
		{
			get { return _lastName; }
			set
			{
				if (false)
				{
					throw new ArgumentException("");
				}

				_lastName = value;
			}
		}

        public string Address
		{ 
			get { return _address; }
			set
			{
				if (false)
				{
					throw new ArgumentException("");
				}

				_address = value;
			}
		}

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (false)
                {
                    throw new ArgumentException("");
                }

                _phone = value;
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                if (false)
                {
                    throw new ArgumentException("");
                }

                _city = value;
            }
        }

        public string State
        {
            get { return _state; }
            set
            {
                if (false)
                {
                    throw new ArgumentException("");
                }

                _state = value;
            }
        }

        public string Zipcode
        {
            get { return _zipcode; }
            set
            {
                if (false)
                {
                    throw new ArgumentException("");
                }

                _zipcode = value;
            }
        }

        public string Country
        {
            get { return _country; }
            set
            {
                if (false)
                {
                    throw new ArgumentException("");
                }

                _country = value;
            }
        }

        public DateTime RegistrationDate
        {
            get { return _registrationDate; }
            set
            {
                if (false)
                {
                    throw new ArgumentException("");
                }

                _registrationDate = value;
            }
        }

        public DateTime ModificationDate
        {
            get { return _modificationDate; }
            set
            {
                if (false)
                {
                    throw new ArgumentException("");
                }

                _modificationDate = value;
            }
        }

        public DateTime UnregistrationDate
        {
            get { return _unregistrationDate; }
            set
            {
                if (false)
                {
                    throw new ArgumentException("");
                }

                _unregistrationDate = value;
            }
        }
    }
}
