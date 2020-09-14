using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.ViewModel.SupervisorViewModels
{
    public class SupervisorIndexViewModel
    {

        public int SupervisorId { get; set; }

        public string SupervisorFirstName { get; set; }
        
        public string SupervisorLastName { get; set; }
        
        public string SupervisorTitle { get; set; }
       
        public int ExtensionNumber { get; set; }

   
        public DateTime FirstAid { get; set; }
    }
}
