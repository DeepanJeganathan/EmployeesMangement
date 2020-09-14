using EmployeesManagementApp.Models;
using EmployeesManagementApp.Services;
using EmployeesManagementApp.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Data
{
    public class HomeRepository : IHomeRepository
    {
        private readonly EmployeeContext _context;

        public HomeRepository(EmployeeContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Department>> GetDeptDetails()
        {
            return await _context.Departments.Include(w => w.Workstations).ThenInclude(e => e.EmployeeWorkstations).ThenInclude(emp => emp.Employee).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetWorkstations()
        {
           return  await _context.Employees.Select(x => new Employee {EmployeeNumber=x.EmployeeNumber,FirstName=x.FirstName,LastName=x.LastName,PayLevel=x.PayLevel, PrimarySkill = x.PrimarySkill, SecondarySkill = x.SecondarySkill,ThirdSkill=x.ThirdSkill }).ToListAsync();
         


        }
    

       public async  Task<IEnumerable<Employee>> GetEmployee()
        {
            return await  _context.Employees.Include(ew => ew.EmployeeWorkstations).ThenInclude(e => e.Workstation).ToListAsync();
        }
    }
}
