using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.ViewModel
{
    public class EmployeeIndexViewModel
    {
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PayLevel { get; set; }
        public DateTime HireDate { get; set; }
        public bool status { get; set; }
        public bool Utility { get; set; }
        public bool FirstAidCertified { get; set; }
        public bool Shipping { get; set; }
    }
}
