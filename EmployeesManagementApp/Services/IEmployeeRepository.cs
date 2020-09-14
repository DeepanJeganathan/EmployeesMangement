using EmployeesManagementApp.Models;
using EmployeesManagementApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Services
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int? id);
        Task<Employee> Search(string searchString);
        Task<Employee> Find(int? id);

        Task CreateEmp(Employee employee);
        Task Update(Employee employee);
        Task Delete(int? id);


        Dictionary<int,string> WorkstationList();
        bool EmployeeExists(int id);
    }
}
