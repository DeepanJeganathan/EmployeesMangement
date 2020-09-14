using EmployeesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.ViewModel
{
    public class EmployeeCreateViewModel
    {
        [Display(Name = "Employee Number")]
        [Required]
        [RegularExpression(@"^([0-9]{4})$", ErrorMessage = "Employee number must be 4 digits")]
        public int EmployeeNumber { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Pay Level")]
        [Required]
        public string PayLevel { get; set; }

        [Display(Name = "Primary Skill")]
        public int PrimarySkill { get; set; }

        [Display(Name = "Secondary Skill")]
        public int? SecondarySkill { get; set; }

        [Display(Name = "Third Skill")]
        public int? ThirdSkill { get; set; }

        [Display(Name = "No Skill")]
        public string NoSkill { get; set; }

        [Display(Name = "Last Worked")]
        [DataType(DataType.Date)]
        public DateTime? SecondarySkillLastOn { get; set; }

        [Display(Name = "Last Worked")]
        [DataType(DataType.Date)]
        public DateTime? ThirdSkillLastOn { get; set; }
       
       
        [System.ComponentModel.DefaultValue(false)]
        public bool Utility { get; set; }


       
        [System.ComponentModel.DefaultValue(true)]
        public bool status { get; set; }

       
        [System.ComponentModel.DefaultValue(false)]
        public bool Shipping { get; set; }

        [Display(Name = "First Aid Certified")]
        [System.ComponentModel.DefaultValue(false)]
        public bool FirstAidCertified { get; set; }

        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]       
        public DateTime HireDate { get; set; }
       
        public Dictionary<int,string> Workstations { get; set; }
    }
}
