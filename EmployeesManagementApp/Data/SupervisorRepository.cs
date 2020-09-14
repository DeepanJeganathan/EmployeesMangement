using EmployeesManagementApp.Models;
using EmployeesManagementApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Data
{
    public class SupervisorRepository : ISupervisorRepository
    {
        private readonly EmployeeContext _context;

        public SupervisorRepository(EmployeeContext context)
        {
            this._context = context;
        }

        public async Task CreateSup(Supervisor supervisor)
        {
            await _context.Supervisors.AddAsync(supervisor);
            await _context.SaveChangesAsync();        

        }

        public async Task Delete(int? id)
        {
            _context.Remove(await _context.Supervisors.FirstOrDefaultAsync(s => s.SupervisorId == id));
            await _context.SaveChangesAsync();
        }

        public bool EmployeeExists(int id)
        {
            return _context.Supervisors.Any(e => e.SupervisorId == id);

        }

        public async Task<Supervisor> Find(int? id)
        {
            return await _context.Supervisors.FindAsync(id);
        }

        public async Task<IEnumerable<Supervisor>> GetAll()
        {
            return await _context.Supervisors.ToListAsync();
        }

        public async Task<Supervisor> GetById(int? id)
        {
            return await _context.Supervisors.FirstOrDefaultAsync(m => m.SupervisorId == id);
        }

        public async Task Update(Supervisor supervisor)
        {
            _context.Update(supervisor);
            await _context.SaveChangesAsync();
        }
    }
}
