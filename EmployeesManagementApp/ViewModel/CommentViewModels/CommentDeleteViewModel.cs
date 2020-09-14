using EmployeesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.ViewModel.CommentViewModel
{
    public class CommentDeleteViewModel
    {
        public int CommentId { get; set; }

        public string Title { get; set; }

        public int EmployeeNumber { get; set; }

        public DateTime Date { get; set; }

        public string Post { get; set; }

        public string SubmittedBy { get; set; }
        public Employee Employee { get; set; }
    }
}
