using EmployeesManagementApp.Models;
using EmployeesManagementApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Data
{
    public class CommentRepository : ICommentRepository

    {
        private readonly EmployeeContext _context;

        public CommentRepository(EmployeeContext context)
        {
            this._context = context;
        }

        public async Task CreateComment(Comment comment)
        {
           await _context.AddAsync(comment);
           await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
           var comment= await _context.Comments.FindAsync(id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public bool CommentExists(int id)
        {
           return _context.Comments.Any(e => e.CommentId == id);
        }

        public async Task<Comment> Find(int? id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
           return await _context.Comments.Include(c => c.Employee).OrderByDescending(x=>x.Date).Take(20).ToListAsync();
        }

        public async Task<Comment> GetById(int? id)
        {
            return await _context.Comments.Include(c => c.Employee).FirstOrDefaultAsync(m => m.CommentId == id);
        }

        public async Task<List<int>> GetEmployeeNums(int empNum)
        {
            return await _context.Employees.Select(x => x.EmployeeNumber).ToListAsync();
        }
       

        public async Task Update(Comment comment)
        {
            _context.Update(comment);
            await _context.SaveChangesAsync();
        }

        public Dictionary<int, List<string>> EmployeeList()
        {
            var dict = _context.Employees.Select(x => new
            {
                x.EmployeeNumber,
                x.LastName,
                x.FirstName

            }).ToDictionary(x => x.EmployeeNumber, x => new List<string> { x.LastName, x.FirstName }) ;

            return dict;
        }
    }
}
