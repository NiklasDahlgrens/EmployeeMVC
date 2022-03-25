using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMVC.Models
{
    public class ModelView
    {
        //Det här är Attributen som ni lägger till själv (Exempelvis Arrangör Attributen)
        public int Id { get; set; }
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }
        [DisplayName("Efternamn")]
        public string LastName { get; set; }
        [DisplayName("Personnummer")]
        public int SecNumber { get; set; }
        [DisplayName("Telefonnummer")]
        public string TelephoneNr { get; set; }
        [DisplayName("Roll")]
        public string Role { get; set; }

        //Det här är kontokoden som lägger till i eran ViewModel
        [DisplayName("Användarnamn")]
        public string Username { get; set; }
        [DisplayName("Lösenord")]
        public string Password { get; set; }
        [DisplayName("Behörighet")]
        public int AccessLevel { get; set; }
        [DisplayName("AnvändareID")]
        public int UserId { get; set; }

    }
}
