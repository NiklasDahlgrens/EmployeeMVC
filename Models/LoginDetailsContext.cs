using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMVC.Models;

namespace EmployeeMVC.Models
{
    public class LoginDetailsContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server = 193.10.202.75; Database = LoginsDetailsDB; User ID = sa; Password = TSB100sql; MultipleActiveResultSets = true");
        }

        internal Task<string> ToListAsync()
        {
            throw new NotImplementedException();
        }

        public DbSet<EmployeeMVC.Models.LoginDetails> LoginDetails { get; set; }
    }
}
