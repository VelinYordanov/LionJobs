using LionJobs.Data.Common;
using LionJobs.Services.Interfaces;
using LionJobs.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LionJobs.Web.Controllers
{
    [Authorize(Roles = "Company")]
    public class ListedJobsController : Controller
    {
        private IListedJobsService jobsService;
        private IEmployeeService employeeService;
        private IUnitOfWork unitOfWork;
        private IImageService imageService;

        public ListedJobsController(IListedJobsService jobsService, IEmployeeService employeeService, IUnitOfWork unitOfWork,IImageService imageService)
        {
            if (jobsService == null)
            {
                throw new ArgumentException("jobservice");
            }

            if (employeeService == null)
            {
                throw new ArgumentException("employeeservice");
            }

            if (unitOfWork == null)
            {
                throw new ArgumentException("unitofwork");
            }

            this.jobsService = jobsService;
            this.employeeService = employeeService;
            this.unitOfWork = unitOfWork;
            this.imageService = imageService;
        }

        // GET: ListedJobs
        public ActionResult Index()
        {
            var Id = User.Identity.GetUserId();
            var jobs = this.jobsService.GetJobs(Id);
            var jobsDto = this.jobsService.MapJobs(jobs);

            return View(jobsDto);
        }


        public ActionResult Details(string id, string job)
        {
            var jobid = job;
            var employee = this.employeeService.GetEmployee(id);
            var employeeModel = new EmployeeHireViewModel
            {
                EmployeeId = id,
                JobId = job,
                FullName = employee.FirstName + " " + employee.LastName,
                Cv = employee.Cv,
                UserImage = this.imageService.ByteArrayToImageUrl(employee.UserImage),
                JobHistory = employee.JobHistory
            };

            return View(employeeModel);
        }

        [HttpPost]
        public ActionResult Details(IdModel ids)
        {
            var jobId = ids.JobId;
            var employeeId = ids.EmployeeId.ToString();
            var employee = this.employeeService.GetEmployee(employeeId);
            var job = this.jobsService.GetJob(jobId);
            this.jobsService.RemoveUserFromJobs(employee, job);

            return RedirectToAction("Index", "Home");
        }
    }
}