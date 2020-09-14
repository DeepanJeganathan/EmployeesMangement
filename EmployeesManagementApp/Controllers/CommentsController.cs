using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeesManagementApp.Data;
using EmployeesManagementApp.Models;
using EmployeesManagementApp.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using EmployeesManagementApp.ViewModel;
using AutoMapper;
using EmployeesManagementApp.ViewModel.CommentViewModel;

namespace EmployeesManagementApp.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMapper _mapper;

        public CommentsController(ICommentRepository commentRepository, IEmployeeRepository employeeRepository, SignInManager<IdentityUser> signInManager, IMapper mapper)
        {
            this._commentRepository = commentRepository;
            this._employeeRepository = employeeRepository;
            this._signInManager = signInManager;
            this._mapper = mapper;
        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var comments = await _commentRepository.GetAll();

            var commentIndexViewModel = new List<CommentIndexViewModel>();

            foreach (var comment in comments)
            {
                commentIndexViewModel.Add(_mapper.Map<CommentIndexViewModel>(comment));
            }
             
            return View(commentIndexViewModel);
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentDetails = await _commentRepository.GetById(id);
            if (commentDetails == null)
            {
                return NotFound();
            }

            var commentDetailViewModel = _mapper.Map<CommentDetailViewModel>(commentDetails);

            return View(commentDetailViewModel);
        }

        // GET: Comments/Create
        public IActionResult Create()
        {
            var model = new CommentCreateViewModel
            {
                EmployeeList = _commentRepository.EmployeeList()
            };

            return View(model);
        }

        // POST: Comments/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,Title,EmployeeNumber,Date,Post,Category")] CommentCreateViewModel commentCreateViewModel)
        {


            try
            {
                var employeeNumber = await _commentRepository.GetEmployeeNums(commentCreateViewModel.EmployeeNumber);
                if (employeeNumber.Contains(commentCreateViewModel.EmployeeNumber))
                {
                    commentCreateViewModel.SubmittedBy = User.FindFirstValue(ClaimTypes.Name);

                    if (ModelState.IsValid)
                    {
                        var comment = _mapper.Map<Comment>(commentCreateViewModel);
                        await _commentRepository.CreateComment(comment);
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Enter a valid Employee Number ");
                }
            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return View(commentCreateViewModel);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _commentRepository.Find(id);
            var commentEditViewModel = _mapper.Map<CommentEditViewModel>(comment);
            if (comment == null)
            {
                return NotFound();
            }

            ViewData["EmployeeNumber"] = new SelectList(await _employeeRepository.GetAll(), "EmployeeNumber", "EmployeeNumber", comment.EmployeeNumber);
            return View(commentEditViewModel);
        }

        // POST: Comments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentId,Title,EmployeeNumber,Date,Post,SubmittedBy,Category")] CommentEditViewModel commentEditViewModel)
        {
            if (id != commentEditViewModel.CommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    commentEditViewModel.SubmittedBy = User.FindFirstValue(ClaimTypes.Name);
                    var comment = _mapper.Map<Comment>(commentEditViewModel);
                    await _commentRepository.Update(comment);
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(commentEditViewModel.CommentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeNumber"] = new SelectList(await _employeeRepository.GetAll(), "EmployeeNumber", "EmployeeNumber", commentEditViewModel.EmployeeNumber);
            return View(commentEditViewModel);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _commentRepository.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }

            var commentDeleteViewModel = _mapper.Map<CommentDeleteViewModel>(comment);

            return View(commentDeleteViewModel);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _commentRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CommentExists(int id)
        {
            return _commentRepository.CommentExists(id);
        }
    }
}
