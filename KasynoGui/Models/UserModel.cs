using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KasynoGui.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }

        public decimal Money { get; set; }

    }

    public class UserHistoryModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public bool isAdd { get; set; }
    
    }
    
}