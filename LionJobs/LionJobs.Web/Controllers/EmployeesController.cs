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

        public EmployeesController(IEmployeeService service,IImageService imageService, IEmployeeListViewModel model)
        {
            this.employeeService = service;
            this.imageService = imageService;
            this.model = model;
        }


        // GET: Employees
        public ActionResult Index()
        {
            var employees = this.employeeService.GetEmployees().Select(x =>
            {
                this.model.FullName = x.FirstName + " " + x.LastName;
                this.model.UserImageUrl = this.imageService.ByteArrayToImageUrl(x.UserImage);
                return this.model;
            });         

            return View(employees);
        }
    }
}