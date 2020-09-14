using EmployeesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.ViewModel
{
    public class CommentCreateViewModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "Please enter a message longer than 5 characters")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Employee Number")]
        public int EmployeeNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Comment is required")]
        [MinLength(10, ErrorMessage = "Please enter a message longer than 10 characters")]
        public string Post { get; set; }

        [Display(Name ="Submitted By")]
        //retrieved using user login id
        public string SubmittedBy { get; set; }

        public Dictionary<int,List<string>> EmployeeList { get; set; }
        
        [Required]
        public Category Category { get; set; }



    }
}
