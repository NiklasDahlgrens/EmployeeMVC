using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMVC.Models;

namespace EmployeeMVC.Models
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public EmployeeContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<EmployeeMVC.Models.ModelView> ModelView { get; set; }
    }
}
