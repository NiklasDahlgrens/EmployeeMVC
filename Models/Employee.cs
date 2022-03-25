using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMVC.Models
{
    public class Employee
    {
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

    }
}
