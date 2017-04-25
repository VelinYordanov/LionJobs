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
    [Authorize(Roles = "Employee")]
    public class FindAJobController : Controller
    {
        private readonly IFindJobService findAJobService;
        private readonly IEmployeeService employeeService;
        private readonly ICompanyService companyService;

        public FindAJobController(IFindJobService findAJobService, IEmployeeService employeeService, ICompanyService companyService)
        {
            if (findAJobService == null)
            {
                throw new ArgumentException("jobservice");
            }

            if(employeeService == null)
            {
                throw new ArgumentException("employeeservice");
            }

            if(companyService == null)
            {
                throw new ArgumentException("companyservice");
            }

            this.findAJobService = findAJobService;
            this.employeeService = employeeService;
            this.companyService = companyService;
        }

        // GET: FindAJob
        public ActionResult Index(int id = 1)
        {
            var jobs = this.findAJobService.GetJobs(id);
            return View(jobs);
        }

        [HttpPost]
        public ActionResult Index(JobIdViewModel model)
        {
            if (User.IsInRole("Employee"))
            {
                var employee = User.Identity.GetUserId();
                var job = this.findAJobService.FindAJob(model.JobId);
                this.findAJobService.AddCandidate(employee, job);
            }

            //this.findAJobService
            return View();
        }

        public ActionResult Apply(string id)
        {
            var userId = User.Identity.GetUserId();
            var user = this.employeeService.GetEmployee(userId);
            if (user.Cv == null)
            {
                this.TempData["Error"] = "You need to have a CV to apply for a job!";
                return Redirect(Request.UrlReferrer.ToString());
            }

            var jobId = new Guid(id);
            var job = this.findAJobService.FindAJob(jobId);

            if(job.JobApplicants.Contains(user))
            {
                this.TempData["Error"] = "Already applied for the job!";
                return Redirect(Request.UrlReferrer.ToString());
            }
            var company = this.findAJobService.GetJobCompany(jobId);
            var jobModel = this.findAJobService.GetJobDescriptionModel(company, job);
            return View(jobModel);
        }

        [HttpPost]
        public ActionResult Apply(Guid Id)
        {
            if (Id != null)
            {
                var jobId = Id;
                var employeeId = User.Identity.GetUserId();
                var job = this.findAJobService.FindAJob(jobId);
                this.findAJobService.AddCandidate(employeeId, job);

                this.TempData["Success"] = "Successfully applied for the job!";
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}