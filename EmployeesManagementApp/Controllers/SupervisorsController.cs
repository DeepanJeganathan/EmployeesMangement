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
using AutoMapper;
using EmployeesManagementApp.ViewModel.SupervisorViewModels;

namespace EmployeesManagementApp.Controllers
{
    public class SupervisorsController : Controller
    {
        private readonly ISupervisorRepository _supervisorRepository;
        private readonly IMapper _mapper;

        public SupervisorsController(ISupervisorRepository supervisorRepository, IMapper mapper)
        {
            this._supervisorRepository = supervisorRepository;
            this._mapper = mapper;
        }

        // GET: Supervisors
        public async Task<IActionResult> Index()
        {
            var supervisors = await _supervisorRepository.GetAll();
            var supervisorIndexViewModel = new List<SupervisorIndexViewModel>();

            foreach (var supervisor in supervisors)
            {
                supervisorIndexViewModel.Add(_mapper.Map<SupervisorIndexViewModel>(supervisor));
            }

           
            return View(supervisorIndexViewModel);
        }

        // GET: Supervisors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisorDetailViewModel = _mapper.Map<SupervisorDetailViewModel>(await _supervisorRepository.GetById(id));
                
            if (supervisorDetailViewModel == null)
            {
                return NotFound();
            }

            return View(supervisorDetailViewModel);
        }

        // GET: Supervisors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supervisors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupervisorId,SupervisorFirstName,SupervisorLastName,SupervisorTitle")] SupervisorCreateViewModel supervisorCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var supervisor = _mapper.Map<Supervisor>(supervisorCreateViewModel);
                await _supervisorRepository.CreateSup(supervisor);
                return RedirectToAction(nameof(Index));
            }
            return View(supervisorCreateViewModel);
        }

        // GET: Supervisors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _supervisorRepository.Find(id);

            if (supervisor == null)
            {
                return NotFound();
            }

            var supervisorEditViewModel = _mapper.Map<SupervisorEditViewModel>(supervisor);
            return View(supervisorEditViewModel);
        }

        // POST: Supervisors/Edit/5     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupervisorId,SupervisorFirstName,SupervisorLastName,SupervisorTitle,ExtensionNumber,FirstAid")] SupervisorEditViewModel supervisorEditViewModel)
        {
            if (id != supervisorEditViewModel.SupervisorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var supervisor = _mapper.Map<Supervisor>(supervisorEditViewModel);
                   await _supervisorRepository.Update(supervisor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupervisorExists(supervisorEditViewModel.SupervisorId))
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
            return View(supervisorEditViewModel);
        }

        // GET: Supervisors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _supervisorRepository.GetById(id);


            if (supervisor == null)
            {
                return NotFound();
            }

            var supervisorDeleteViewModel = _mapper.Map<SupervisorDeleteViewModel>(supervisor);
            return View(supervisorDeleteViewModel);
        }

        // POST: Supervisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _supervisorRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SupervisorExists(int id)
        {
            return _supervisorRepository.EmployeeExists(id);
        }
    }
}
