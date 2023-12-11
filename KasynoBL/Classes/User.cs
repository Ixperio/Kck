using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kasyno.Repository.Controllers;

namespace Kasyno.Classes
{
   
    internal class User
    {
        UserController _userController = new UserController();
        private string Name;
        private string Surname;
        private string Email;
        private int Age;
        private decimal Balance;
        private string Password;


        /**
         * Getters Methods
         */

        public string GetName()
        {
            return this.Name;
        }
        public string GetSurname()
        {
            return this.Surname;
        }
        public string GetEmail()
        {
            return this.Email;
        }

        public decimal GetBalance()
        {
            return this.Balance;
        }

        public int GetAge()
        {
            return this.Age;
        }
        
        public Boolean ComparePassword(string password)
        {
            if(this.Password == password) return true;
            else return false;
        }

        public string GetPassword()
        {
            return this.Password;
        }

        /**
         * Setters Methods
         */

        public void SetName(string name)
        {
            this.Name = name;
        }
        public void SetSurname(string surname)
        {
            this.Surname = surname;
        }
        public void SetEmail(string email)
        {
            this.Email = email;
        }

        public void SetAge(int age)
        {
            this.Age = age;
        
        }
        public void SetBalance(decimal balance)
        {
            this.Balance = balance;
        }

        public void SetPassword(string password)
        {
            this.Password = password;

        }

        /**
         * Updates methods
         */

        public void AddBalance(decimal balance)
        {
            this.Balance += balance;
            _userController.NadpiszPlik(this);

        }
        public Boolean RemoveBalance(decimal balance)
        {
            if(this.GetBalance() >= balance)
            {
                this.Balance -= balance;
                _userController.NadpiszPlik(this);
                if (this.Balance < 0)
                {
                    this.Balance = 0;
                }
                return true;
            }
            else
            {
                return false;
            }

          
            
        }

        public User Register(string name, string surname,int age, string email, string password)
        {
                    this.SetName(name);
                    this.SetSurname(surname);
                    this.SetAge(age);
                    this.SetEmail(email);
                    this.SetPassword(password);
                    this.SetBalance(0.0m);

            return this;
        }

    }
}
