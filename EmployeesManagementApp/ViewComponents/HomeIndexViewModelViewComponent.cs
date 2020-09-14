using EmployeesManagementApp.Data;
using EmployeesManagementApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.ViewComponents
{
    public class HomeIndexViewModelViewComponent:ViewComponent

    {

        private readonly EmployeeContext _context;

        public HomeIndexViewModelViewComponent(EmployeeContext context)
        {
            _context = context;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

           var empList= await _context.Employees.Select(x => x.LastName).ToListAsync() ;
            ViewData["Employee-List"] = new List<string> (empList); 

            var employees = await _context.Employees.ToListAsync();

            var supervisors =await _context.Supervisors.ToListAsync();

            var workstations = await _context.Workstations.ToListAsync();

            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
            {
                Employees = employees,
                Supervisors = supervisors,
                Workstations= workstations

            };
            return View( homeIndexViewModel);

        }

    }
}
