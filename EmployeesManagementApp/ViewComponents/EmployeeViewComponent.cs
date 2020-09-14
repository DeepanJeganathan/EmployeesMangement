using EmployeesManagementApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.ViewComponents
{


    public class EmployeeViewComponent:ViewComponent
    {

        private readonly EmployeeContext _context;

        public EmployeeViewComponent( EmployeeContext context)
        {

            _context = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            

            return View(await _context.Employees.ToListAsync());

        }













    }
}
