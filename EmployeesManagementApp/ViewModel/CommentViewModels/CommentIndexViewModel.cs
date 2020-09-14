using EmployeesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.ViewModel.CommentViewModel
{
    public class CommentIndexViewModel
    {
        public int CommentId { get; set; }

        public string Title { get; set; }
        
        public int EmployeeNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        
        public string Post { get; set; }
        
        public string SubmittedBy { get; set; }
        
        public Category Category { get; set; }
        public Employee Employee { get; set; }
    }
}
