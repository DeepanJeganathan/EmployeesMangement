using EmployeesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Services
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAll();
        Task<Comment> GetById(int? id);
        Task<List<int>> GetEmployeeNums(int empNum);
        Task<Comment> Find(int? id);

        Task CreateComment(Comment comment);
        Task Update(Comment comment);
        Task  Delete(int? id);

        Dictionary<int, List<string>> EmployeeList();
        bool CommentExists(int id);
    }
}
