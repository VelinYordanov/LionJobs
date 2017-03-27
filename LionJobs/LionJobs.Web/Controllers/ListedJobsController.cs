using LionJobs.Data.Common;
using LionJobs.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LionJobs.Web.Controllers
{
    public class ListedJobsController : Controller
    {
        private IListedJobsService jobsService;
        private IEmployeeService employeeService;
        private IUnitOfWork unitOfWork;

        public ListedJobsController(IListedJobsService jobsService, IEmployeeService employeeService, IUnitOfWork unitOfWork)
        {
            this.jobsService = jobsService;
            this.employeeService = employeeService;
            this.unitOfWork = unitOfWork;
        }

        // GET: ListedJobs
        public ActionResult Index()
        {
            var Id = User.Identity.GetUserId();
            var jobs = this.jobsService.GetJobs(Id);
            var jobsDto = this.jobsService.MapJobs(jobs);

            return View(jobsDto);
        }

        
        public ActionResult Details(string Id)
        {
            var employee = this.employeeService.GetEmployee(Id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Details(Guid id)
        {
            var employeeId = id.ToString();
            var employee = this.employeeService.GetEmployee(employeeId);
            this.jobsService.RemoveUserFromJobs(employee,this.unitOfWork);

            return RedirectToAction("Index", "Home");
        }
    }
}