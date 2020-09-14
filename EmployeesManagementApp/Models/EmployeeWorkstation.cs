using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Models
{
    public class EmployeeWorkstation
    {
        

        public int EmployeeNumber { get; set; }
        public Employee Employee { get; set; }

        public int WorkstationNumber { get; set; }

        public Workstation Workstation { get; set; }

        
    }
}
