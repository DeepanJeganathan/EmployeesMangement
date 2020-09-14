using EmployeesManagementApp.Models;
using EmployeesManagementApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Services
{
    public interface IHomeRepository
    {
        Task <IEnumerable<Department>> GetDeptDetails();
        Task <IEnumerable<Employee>> GetWorkstations();
        Task<IEnumerable<Employee>> GetEmployee();
    }
}
