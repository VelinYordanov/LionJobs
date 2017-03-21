using LionJobs.Models;
using LionJobs.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LionJobs.Web.Controllers
{
    [Authorize(Roles ="Company")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService service;
        public EmployeesController(IEmployeeService service)
        {
            this.service = service;
        }

        
        // GET: Employees
        public ActionResult Index()
        {
            var employees = this.service.GetEmployees();
            //IEnumerable<>
            return View(this.service.GetEmployees());
        }
    }
}