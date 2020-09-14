using EmployeesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Services
{
    public interface IDisciplineStagesRepository
    {
        Task<IEnumerable<DisciplineStage>> GetAll();
        Task<DisciplineStage> GetById(int? id);
        Dictionary<int, List<string>> EmployeeList();
        Task<DisciplineStage> Find(int? id);

        Task CreateDiscipline(DisciplineStage disciplineStage);
        Task Update(DisciplineStage disciplineStage);
        Task Delete(int? id);
        bool DisciplineStageExists(int id);
    }
}
