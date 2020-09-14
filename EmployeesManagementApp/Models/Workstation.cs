using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Models
{
    public class Workstation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        
        public int WorkstationNumber { get; set; }

        public int DepartmentId { get; set; }

        [Required]
        public string WorkstationName { get; set; }
      
        public IList<EmployeeWorkstation> EmployeeWorkstations { get; set; }

        public Department Department { get; set; }
    }
}
