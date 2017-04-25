using LionJobs.Models;
using LionJobs.Services;
using LionJobs.Services.Interfaces;
using LionJobs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LionJobs.Web.Controllers
{
    [Authorize(Roles = "Company")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IEmployeeListViewModel model;
        private readonly IImageService imageService;

        public EmployeesController(IEmployeeService service, IImageService imageService, IEmployeeListViewModel model)
        {
            if (service == null)
            {
                throw new ArgumentException("employee");
            }

            if (imageService == null)
            {
                throw new ArgumentException("imageservice");
            }

            if (model == null)
            {
                throw new ArgumentException("viewmodel");
            }

            this.employeeService = service;
            this.imageService = imageService;
            this.model = model;
        }


        // GET: Employees
        public ActionResult Index()
        {
            var employees = this.employeeService.GetEmployeesList();

            return View(employees);
        }
    }
}