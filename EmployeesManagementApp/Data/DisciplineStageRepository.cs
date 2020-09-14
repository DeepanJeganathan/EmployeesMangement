using EmployeesManagementApp.Models;
using EmployeesManagementApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Data
{
    public class DisciplineStageRepository : IDisciplineStagesRepository
    {
        private readonly EmployeeContext _context;

        public DisciplineStageRepository(EmployeeContext context)
        {
            this._context = context;
        }
      
        public async Task CreateDiscipline(DisciplineStage disciplineStage)
        {
          await  _context.AddAsync(disciplineStage);
           await _context.SaveChangesAsync();

        }

        public async Task Delete(int? id)
        {
            var disciplineStage= await _context.DisciplineStages.FindAsync(id);
            _context.DisciplineStages.Remove(disciplineStage);
            await _context.SaveChangesAsync();
        }

        public bool DisciplineStageExists(int id)
        {
            return _context.DisciplineStages.Any(e => e.DisciplineStageId == id);
        }

        public Dictionary<int, List<string>> EmployeeList()
        {
            return _context.Employees.Select(x => new { x.EmployeeNumber, x.FirstName, x.LastName }).ToDictionary(x => x.EmployeeNumber, x => new List<string> { x.FirstName, x.LastName });
        }

        public async Task<DisciplineStage> Find(int? id)
        {
            return await _context.DisciplineStages.FindAsync(id);
        }

        public async Task<IEnumerable<DisciplineStage>> GetAll()
        {
            return await _context.DisciplineStages.Include(x=>x.Employee).ToListAsync();
        }

        public async Task<DisciplineStage> GetById(int? id)
        {
          return await  _context.DisciplineStages.Include(d => d.Employee).FirstOrDefaultAsync(m => m.DisciplineStageId == id);
        }

        public async Task Update(DisciplineStage disciplineStage)
        {
            _context.Update(disciplineStage);
            await _context.SaveChangesAsync();
        }
    }
}
