using EmployeesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.ViewModel.AbsenceViewModels
{
    public class AbsenceEditViewModel
    {
        public int AbsenceTrackerId { get; set; }


        public int NumberOfAbsences { get; set; }


        public bool? StepOne { get; set; }


        public DateTime? StepOneDate { get; set; }


        public bool? StepTwo { get; set; }


        public DateTime? StepTwoDate { get; set; }


        public bool? StepThree { get; set; }

        public DateTime? StepThreeDate { get; set; }

        public int  EmployeeNumber { get; set; }
        public Employee Employee { get; set; }
    }
}
