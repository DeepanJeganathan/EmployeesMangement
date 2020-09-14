using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Models
{
    public class Absence

    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AbsenceTrackerId { get; set; }

        [Display(Name = "Number of Absences")]
        public int NumberOfAbsences { get; set; }

        [Display(Name = " Step One")]
        public bool? StepOne { get; set; }

        [Display(Name = " Date completed")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StepOneDate { get; set; }


        [Display(Name = " Step Two")]
        public bool? StepTwo { get; set; }

        [Display(Name = " Date completed")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StepTwoDate { get; set; }

        [Display(Name = " Step Three")]
        public bool? StepThree { get; set; }

        [Display(Name = " Date completed")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StepThreeDate { get; set; }

        [Display(Name = " Date completed")]
        [Required]
        public int EmployeeNumber { get; set; }

        public Employee Employee { get; set; }
    }
}
