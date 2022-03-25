using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMVC.Models
{
    public class LoginDetails
    {
        
        public int Id { get; set; }
        [DisplayName("Användarnamn")]
        public string Username { get; set; }
        [DisplayName("Lösenord")]
        public string Password { get; set; }
        [DisplayName("Behörighetsnivå")]
        public int AccessLevel { get; set; }
        [DisplayName("AnvändareID")]
        public int UserId { get; set; }
    }
}
