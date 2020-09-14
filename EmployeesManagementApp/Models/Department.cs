using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Display(Name = " Department Number")]
        [Required]
        public int DepartmentNumber { get; set; }

        [Display(Name = " Department Name")]
        [Required]
        public string DepartmentName { get; set; }

        [Display(Name = " Supervisor Id")]
        public int SupervisorId { get; set; }
       

        public List<Workstation> Workstations { get; set; }

        public List<Supervisor> Supervisors { get; set; }


    }
}
