using EmployeesManagementApp.Models;
using EmployeesManagementApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Data
{
    public class AbsenceRepository : IAbsenceRepository
    {
        private readonly EmployeeContext _context;

        public AbsenceRepository(EmployeeContext context)
        {
            this._context = context;
        }
        public bool AbsenceExists(int id)
        {
            return _context.Absences.Any(e => e.AbsenceTrackerId == id);
        }

        public async Task CreateAbs(Absence absence)
        {
            _context.Add(absence);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var absence=await _context.Absences.FindAsync(id);
            _context.Absences.Remove(absence);
            await _context.SaveChangesAsync();

        }

        public async Task<Absence> Find(int? id)
        {
          return await _context.Absences.FindAsync(id);
        }

        public async Task<IEnumerable<Absence>> GetAll()
        {
           return await _context.Absences.Include(a => a.Employee).OrderByDescending(x => x.NumberOfAbsences).ToListAsync();
        }

        public async Task<Absence> GetById(int? id)
        {
           return await _context.Absences.Include(a => a.Employee).FirstOrDefaultAsync(m => m.AbsenceTrackerId == id);
        }

        public async Task Update(Absence absence)
        {
            _context.Update(absence);
            await _context.SaveChangesAsync(); ;
        }
    }
}
