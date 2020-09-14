using EmployeesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.ViewModel
{
    public class EmployeeDetailViewModel
    {
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PayLevel { get; set; }
        public int PrimarySkill { get; set; }
        public int? SecondarySkill { get; set; }
        public DateTime? SecondarySkillLastOn { get; set; }
        public int? ThirdSkill { get; set; }
        public DateTime? ThirdSkillLastOn { get; set; }
        public string NoSkill { get; set; }
        public DateTime HireDate { get; set; }
        public bool status { get; set; }
        public bool Utility { get; set; }
        public bool FirstAidCertified { get; set; }
        public bool Shipping { get; set; }
        public IList<Comment> Comments { get; set; }

       
    }
}
