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
using EmployeesManagementApp.ViewModel;
using EmployeesManagementApp.ViewModel.AbsenceViewModels;

namespace EmployeesManagementApp.Controllers
{
    public class AbsencesController : Controller
    {
        private readonly IAbsenceRepository _absenceRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public AbsencesController(IAbsenceRepository absenceRepository,IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this._absenceRepository = absenceRepository;
            this._employeeRepository = employeeRepository;
            this._mapper = mapper;
        }

        // GET: Absences
        public async Task<IActionResult> Index()
        {
            var absences =await  _absenceRepository.GetAll();
            var absenceIndexViewModel = new List<AbsenceIndexViewModel>();
            foreach (var absence in absences)
            {
                absenceIndexViewModel.Add(_mapper.Map<AbsenceIndexViewModel>(absence));
            }
            
                
                return View(absenceIndexViewModel);
        }

        // GET: Absences/Create
        public async Task<IActionResult> Create()
        {
            ViewData["EmployeeNumber"] = new SelectList(await _employeeRepository.GetAll(), "EmployeeNumber", "EmployeeNumber");
            return View();
        }

        // POST: Absences/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AbsenceTrackerId,NumberOfAbsences,StepOne,StepOneDate,StepTwo,StepTwoDate,StepThree,StepThreeDate,EmployeeNumber")] AbsenceCreateViewModel absenceCreateViewModel)
        {
            try
            {
                if (ModelState.IsValid)

                {
                    var absence = _mapper.Map<Absence>(absenceCreateViewModel);

                    await _absenceRepository.CreateAbs(absence);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. Is the employee already on file? " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            ViewData["EmployeeNumber"] = new SelectList(await _employeeRepository.GetAll(), "EmployeeNumber", "EmployeeNumber");
            return View(absenceCreateViewModel);
        }

        // GET: Absences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absence = await _absenceRepository.Find(id);

            if (absence == null)
            {
                return NotFound();
            }

            var absenceEditViewModel = _mapper.Map<AbsenceEditViewModel>(absence);

            ViewData["EmployeeNumber"] = new SelectList(await _employeeRepository.GetAll(), "EmployeeNumber", "EmployeeNumber", absence.EmployeeNumber);
            return View(absenceEditViewModel);
        }

        // POST: Absences/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AbsenceTrackerId,NumberOfAbsences,StepOne,StepOneDate,StepTwo,StepTwoDate,StepThree,StepThreeDate,EmployeeNumber")] AbsenceEditViewModel absenceEditViewModel)
        {
            if (id != absenceEditViewModel.AbsenceTrackerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var absence = _mapper.Map<Absence>(absenceEditViewModel);

                    await _absenceRepository.Update(absence);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbsenceExists(absenceEditViewModel.AbsenceTrackerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes. " +
                                "Try again, and if the problem persists, " +
                                 "see your system administrator.");
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeNumber"] = new SelectList(await _employeeRepository.GetAll(), "EmployeeNumber", "EmployeeNumber", absenceEditViewModel.EmployeeNumber);
            return View(absenceEditViewModel);
        }

        // GET: Absences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absence = await _absenceRepository.GetById(id);
            var absenceDeleteViewModel = _mapper.Map<AbsenceDeleteViewModel>(absence);
               
            if (absence == null)
            {
                return NotFound();
            }

            return View(absenceDeleteViewModel);
        }

        // POST: Absences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _absenceRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AbsenceExists(int id)
        { 
            return _absenceRepository.AbsenceExists(id);
        }
    }

}
