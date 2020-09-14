using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeesManagementApp.Models;
using EmployeesManagementApp.Data;
using EmployeesManagementApp.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Net;
using EmployeesManagementApp.Services;

namespace EmployeesManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepository _homeRepository;

        public HomeController(IHomeRepository homeRepository)
        {
            this._homeRepository = homeRepository;
        }

        public IActionResult Index(int search)
        {
            

            return View();
           
        }
        public async Task<IActionResult> Flow(int id)
        {

            var viewModel = new HomeFlowViewModel();

            viewModel.Departments =await _homeRepository.GetDeptDetails();
                        
            if (id ==1 || id==2 || id==3 ||id==4 )
            {

                viewModel.Departments = from e in viewModel.Departments
                                        where e.DepartmentId.Equals(id)
                                        select e;
            }
            else
            {
                return RedirectToRoute(new { controller = "Home", action = "About" });
            }

            return View(viewModel);
        }

        public async Task<IActionResult> SearchByWorkstation(string search)
        {

            ViewData["currentFilter"] = search;

            var viewModel = new HomeFlowViewModel();

            viewModel.Employees = await _homeRepository.GetWorkstations();
            if (!string.IsNullOrEmpty(search))
            {
                viewModel.Employees = from e in viewModel.Employees
                                      where e.PrimarySkill.Equals(int.Parse(search))|| e.SecondarySkill.Equals(int.Parse(search))|| e.ThirdSkill.Equals(int.Parse(search))
                                      orderby e.PrimarySkill.Equals(int.Parse(search)),
                                      e.SecondarySkill.Equals(int.Parse(search)), e.ThirdSkill.Equals(int.Parse(search))
                                      select e;
            }

            return View(viewModel);
        }

        public async Task<IActionResult> SearchByEmployeeNumber(string search)
        {

            ViewData["currentFilter"] = search;

            var viewModel = new HomeFlowViewModel();

            viewModel.Employees = await _homeRepository.GetEmployee();

            if (!string.IsNullOrEmpty(search))
            {
                viewModel.Employees = from e in viewModel.Employees
                                         where e.EmployeeNumber.ToString().Equals(search)
                                         select e;
            }

            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
