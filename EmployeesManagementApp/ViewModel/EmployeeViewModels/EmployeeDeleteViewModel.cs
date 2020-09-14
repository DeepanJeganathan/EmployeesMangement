using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.ViewModel
{
    public class EmployeeDeleteViewModel
    {
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PayLevel { get; set; }
        public int PrimarySkill { get; set; }
        public int? SecondarySkill { get; set; }
        public int? ThirdSkill { get; set; }
        public string NoSkill { get; set; }
        public DateTime HireDate { get; set; }


    }
}
