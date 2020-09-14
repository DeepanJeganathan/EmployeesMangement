using EmployeesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Services
{
    public interface IAbsenceRepository
    {

        Task<IEnumerable<Absence>> GetAll();
        Task<Absence> GetById(int? id);
        Task CreateAbs(Absence absence);
        Task<Absence> Find(int? id);
        
        Task Update(Absence absence);
        Task Delete(int? id);
        bool AbsenceExists(int id);

    }
}
