using EmployeesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Services
{
     public interface ISupervisorRepository
    {
        Task<IEnumerable<Supervisor>> GetAll();
        Task<Supervisor> GetById(int? id);

        Task<Supervisor> Find(int? id);

        Task CreateSup(Supervisor supervisor);
        Task Update(Supervisor supervisor);
        Task Delete(int? id);

        bool EmployeeExists(int id);


    }
}
