using EmployeesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.DTOs
{
    public class EmployeeDTO
    {
        [Required]
        public int EmployeeNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public string PayLevel { get; set; }


        public int PrimarySkill { get; set; }

        public int? SecondarySkill { get; set; }

        public int? ThirdSkill { get; set; }

        public string NoSkill { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool status { get; set; }

        [System.ComponentModel.DefaultValue(false)]
        public bool Shipping { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString ="{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        public IList<EmployeeWorkstation> EmployeeWorkstations { get; set; }

        public IList<Comment> Comments { get; set; }
        public Absence Absence { get; set; }

    }
}
