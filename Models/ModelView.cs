using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMVC.Models
{
    public class ModelView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SecNumber { get; set; }
        public string TelephoneNr { get; set; }
        public string Role { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public int AccessLevel { get; set; }
        public int UserId { get; set; }

    }
}
