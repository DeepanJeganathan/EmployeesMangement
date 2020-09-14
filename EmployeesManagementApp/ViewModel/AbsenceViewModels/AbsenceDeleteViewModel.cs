using EmployeesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.ViewModel.AbsenceViewModels
{
    public class AbsenceDeleteViewModel
    {
        public int AbsenceTrackerId { get; set; }

        public int EmployeeNumber { get; set; }

        public Employee Employee { get; set; }
    }
}
