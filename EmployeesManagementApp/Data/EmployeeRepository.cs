using EmployeesManagementApp.Models;
using EmployeesManagementApp.Services;
using EmployeesManagementApp.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Data
{
    public class EmployeeRepository : IEmployeeRepository

    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            this._context = context;
        }


        public async Task<IEnumerable<Employee>> GetAll()
        {

            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int? id)
        {

            return await _context.Employees.Include(c => c.Comments).FirstOrDefaultAsync(m => m.EmployeeNumber == id);

        }

        public async Task CreateEmp(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            //add entry to the Emp/wrk join table
            EmployeeWorkstation employeeWorkstation = new EmployeeWorkstation { };
            employeeWorkstation.EmployeeNumber = employee.EmployeeNumber;
            employeeWorkstation.WorkstationNumber = employee.PrimarySkill;

            await _context.EmployeeWorkstations.AddAsync(employeeWorkstation);
            await _context.SaveChangesAsync();


        }

        public Task<Employee> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> Find(int? id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task Update(Employee employee)
        {
            var primarySkill = _context.Employees.Where(x => x.EmployeeNumber.Equals(employee.EmployeeNumber)).Select(x => x.PrimarySkill).FirstOrDefault();

            if (employee.PrimarySkill != primarySkill)
            {
                EmployeeWorkstation employeeWorkstation = new EmployeeWorkstation { };
                employeeWorkstation.EmployeeNumber = employee.EmployeeNumber;
                employeeWorkstation.WorkstationNumber = employee.PrimarySkill;

                _context.EmployeeWorkstations.Update(employeeWorkstation);
                await _context.SaveChangesAsync();
            }
            _context.Update(employee);
            await _context.SaveChangesAsync();
           
            

        }

        public async Task Delete(int? id)
        {
            _context.Remove(await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeNumber == id));
            await _context.SaveChangesAsync();

        }

        public bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeNumber == id);
        }

        public Dictionary<int, string> WorkstationList()
        {
            var dict = _context.Workstations.Select(x => new
            {
                x.WorkstationNumber,
                x.WorkstationName
            }).ToDictionary(x => x.WorkstationNumber, x => x.WorkstationName);

            return dict;

        }
    }
}
