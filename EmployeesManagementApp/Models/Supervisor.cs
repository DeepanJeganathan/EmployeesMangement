using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Models
{
    public class Supervisor
    {
        public int SupervisorId { get; set; }
        [Required]
        public string SupervisorFirstName { get; set; }
        [Required]
        public string SupervisorLastName { get; set; }
        [Required]
        public string SupervisorTitle { get; set; }
        [Required]
        public int ExtensionNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FirstAid{ get; set; }

        public Department Departments { get; set; }

    }
}
