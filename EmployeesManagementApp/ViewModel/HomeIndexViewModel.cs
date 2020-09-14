using EmployeesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.ViewModel
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Employee>  Employees { get; set; }
        public IEnumerable<Supervisor> Supervisors { get; set; }

        public IEnumerable<Workstation> Workstations { get; set; }

        public IEnumerable<Department> Departments { get; set; }
    }
}
