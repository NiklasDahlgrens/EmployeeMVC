using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMVC.Models
{
    public class ModelView
    {
        //Det här är Attributen som ni lägger till själv (Exempelvis Arrangör Attributen)
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SecNumber { get; set; }
        public string TelephoneNr { get; set; }
        public string Role { get; set; }

        //Det här är kontokoden som lägger till i eran ViewModel
        public string Username { get; set; }
        public string Password { get; set; }
        public int AccessLevel { get; set; }
        public int UserId { get; set; }

    }
}
