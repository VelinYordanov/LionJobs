using LionJobs.Models;
using LionJobs.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LionJobs.Web.Controllers
{
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
            return View(this.service.GetEmployees());
        }
    }
}