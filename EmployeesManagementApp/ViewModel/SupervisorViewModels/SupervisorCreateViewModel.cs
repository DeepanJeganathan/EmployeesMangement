using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.ViewModel.SupervisorViewModels
{
    public class SupervisorCreateViewModel
    {
        
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
        public DateTime FirstAid { get; set; }
    
    }
}
