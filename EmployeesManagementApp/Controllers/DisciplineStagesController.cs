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
using EmployeesManagementApp.ViewModel;

namespace EmployeesManagementApp.Controllers
{
    public class DisciplineStagesController : Controller
    {
        
        private readonly IDisciplineStagesRepository _disciplineStagesRepository;

        public DisciplineStagesController(IDisciplineStagesRepository disciplineStagesRepository)
        {
           
            this._disciplineStagesRepository = disciplineStagesRepository;
        }

        // GET: DisciplineStages
        public async Task<IActionResult> Index()
        {
            
            return View(await _disciplineStagesRepository.GetAll());
        }

        // GET: DisciplineStages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplineStage = await _disciplineStagesRepository.GetById(id);
            if (disciplineStage == null)
            {
                return NotFound();
            }

            return View(disciplineStage);
        }

        // GET: DisciplineStages/Create
        public IActionResult Create()
        {
            var model = new DisciplineStageCreateViewModel()
            {
                EmployeeList = _disciplineStagesRepository.EmployeeList()
            };
            return View(model);
        }

        // POST: DisciplineStages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VerbalWarning,Written,OneDay,ThreeDay,FiveDay,TwoWeek,ThirtyDay,EmployeeNumber")] DisciplineStageCreateViewModel disciplineStage)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var disciplineStagedb = new DisciplineStage()
                    {
                        EmployeeNumber = disciplineStage.EmployeeNumber,
                        VerbalWarning = disciplineStage.VerbalWarning,
                        OneDay = disciplineStage.OneDay,                        
                        ThreeDay = disciplineStage.ThreeDay,                        
                        FiveDay = disciplineStage.FiveDay,
                        TwoWeek=disciplineStage.TwoWeek,
                        ThirtyDay=disciplineStage.ThirtyDay,
                        Written = disciplineStage.Written
                    };

                    await _disciplineStagesRepository.CreateDiscipline(disciplineStagedb);
                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Enter a valid Employee Number ");
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                   "Try again, and if the problem persists " +
                   "see your system administrator.");
            }

            return View(disciplineStage);
        }

        // GET: DisciplineStages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplineStage = await _disciplineStagesRepository.Find(id);
            if (disciplineStage == null)
            {
                return NotFound();
            }
            //ViewData["EmployeeNumber"] = new SelectList(_context.Employees, "EmployeeNumber", "FirstName", disciplineStage.EmployeeNumber);
            return View(disciplineStage);
        }

        // POST: DisciplineStages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisciplineStageId,VerbalWarning,Written,OneDay,TwoDay,ThreeDay,FourDay,FiveDay,EmployeeNumber")] DisciplineStage disciplineStage)
        {
            if (id != disciplineStage.DisciplineStageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _disciplineStagesRepository.Update(disciplineStage);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplineStageExists(disciplineStage.DisciplineStageId))
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
            //ViewData["EmployeeNumber"] = new SelectList(_context.Employees, "EmployeeNumber", "FirstName", disciplineStage.EmployeeNumber);
            return View(disciplineStage);
        }

        // GET: DisciplineStages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplineStage = await _disciplineStagesRepository.GetById(id);
            if (disciplineStage == null)
            {
                return NotFound();
            }

            return View(disciplineStage);
        }

        // POST: DisciplineStages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _disciplineStagesRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplineStageExists(int id)
        {
            return _disciplineStagesRepository.DisciplineStageExists(id);
        }
    }
}
