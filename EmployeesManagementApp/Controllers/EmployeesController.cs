using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeesManagementApp.Data;
using EmployeesManagementApp.Models;
using EmployeesManagementApp.ViewModel;
using EmployeesManagementApp.Services;
using Newtonsoft.Json;
using AutoMapper;


namespace EmployeesManagementApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this._employeeRepository = employeeRepository;
            this._mapper = mapper;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string searchString, string currentFilter, string sortOrder, int? pageNumber,string status,bool isFirstAid)
        {
            var employees = await _employeeRepository.GetAll();
            

            if (!string.IsNullOrWhiteSpace(status))
            {
                employees = employees.Where(x => x.status.Equals(bool.Parse(status)));
            }
            if (isFirstAid==true)
            {
                employees = employees.Where(x => x.FirstAidCertified.Equals(true));
            }

            ViewData["employeeNames"] = JsonConvert.SerializeObject(employees.Select(x => x).ToList());
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            
            ViewData["EmpList"] = employees.Select(x => x.LastName).ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
               
               employees =  employees.Where(e => e.LastName.ToLower().Contains(searchString.ToLower()));  

            }
            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    employees = employees.OrderBy(s => s.HireDate);
                    break;
                case "date_desc":
                    employees = employees.OrderByDescending(s => s.HireDate);
                    break;
                default:
                    employees = employees.OrderBy(s => s.LastName);
                    break;
            }

            var employeesViewModel = new List<EmployeeIndexViewModel>();
            foreach (var emp in employees)
            {
                employeesViewModel.Add( _mapper.Map<EmployeeIndexViewModel>(emp));
            }


            int pageSize = 25;
            return View( PaginatedList<EmployeeIndexViewModel>.Create(employeesViewModel.AsQueryable(), pageNumber ?? 1, pageSize));                       
        }

        //GET:Employees/shipping
        public async Task<IActionResult> shipping(string searchString, string currentFilter, string sortOrder, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var employees = await _employeeRepository.GetAll();
            employees = employees.Where(s => s.Shipping.Equals(true));

            if (!String.IsNullOrEmpty(searchString))
            {

                employees = employees.Where(e => e.LastName.ToLower().Contains(searchString.ToLower()));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    employees = employees.OrderBy(s => s.HireDate);
                    break;
                case "date_desc":
                    employees = employees.OrderByDescending(s => s.HireDate);
                    break;
                default:
                    employees = employees.OrderBy(s => s.LastName);
                    break;
            }

            var employeesViewModel = new List<EmployeeIndexViewModel>();
            foreach (var emp in employees)
            {
                employeesViewModel.Add(_mapper.Map<EmployeeIndexViewModel>(emp));
            }


            int pageSize = 25;
            return View(PaginatedList<EmployeeIndexViewModel>.Create(employeesViewModel.AsQueryable(), pageNumber ?? 1, pageSize));

        }

        //GET:Employees/details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee =await _employeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            var employeeDetailViewModel = _mapper.Map<EmployeeDetailViewModel>(employee);

            return View(employeeDetailViewModel);
        }

            // GET: Employees/Create
            public IActionResult Create()
        {
            var model = new EmployeeCreateViewModel()
            {
                Workstations = _employeeRepository.WorkstationList()
        };

            return View(model);
        }

        // POST: Employees/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeNumber,FirstName,LastName,PayLevel,PrimarySkill,SecondarySkill,ThirdSkill,NoSkill,HireDate,Shipping,status,FirstAidCertified,Utility,SecondarySkillLastOn,ThirdSkillLastOn")] EmployeeCreateViewModel employeeCreateViewModel)
        {

            if (_employeeRepository.EmployeeExists(employeeCreateViewModel.EmployeeNumber))
            {
                ModelState.AddModelError("", "Employee number already exists");
            }

            else
            {

                try
                {
                    if (ModelState.IsValid)
                    {

                        var employee = _mapper.Map<Employee>(employeeCreateViewModel);
 
                        await _employeeRepository.CreateEmp(employee);

                        return RedirectToAction(nameof(Index));
                    }

                }

                catch (DbUpdateException)
                {

                    ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists " +
                "see your system administrator.");


                }
            }

            employeeCreateViewModel.Workstations= _employeeRepository.WorkstationList();

            return View(employeeCreateViewModel);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepository.Find(id);

            if (employee == null)
            {
                return NotFound();
            }
            var employeeEditViewModel = _mapper.Map<EmployeeEditViewModel>(employee);

            employeeEditViewModel.Workstations = _employeeRepository.WorkstationList();

            return View(employeeEditViewModel);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeNumber,FirstName,LastName,PayLevel,PrimarySkill,SecondarySkill,ThirdSkill,NoSkill,HireDate,Shipping,status,FirstAidCertified,Utility,SecondarySkillLastOn,ThirdSkillLastOn")] EmployeeEditViewModel employeeEditViewModel)
        {
            if (id != employeeEditViewModel.EmployeeNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var employeeDb = _mapper.Map<Employee>(employeeEditViewModel);

                    await _employeeRepository.Update(employeeDb);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employeeEditViewModel.EmployeeNumber))
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
            employeeEditViewModel.Workstations = _employeeRepository.WorkstationList();

            return View(employeeEditViewModel);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee =await _employeeRepository.GetById(id);
          
           
            if (employee == null)
            {
                return NotFound();
            }
            var employeeDeleteViewModel = _mapper.Map<EmployeeDeleteViewModel>(employee);

            return View(employeeDeleteViewModel);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employeeRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _employeeRepository.EmployeeExists(id);
        }
    }
}