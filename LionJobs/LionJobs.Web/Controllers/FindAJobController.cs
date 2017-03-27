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
    [Authorize(Roles ="Employee")]
    public class FindAJobController : Controller
    {
        private IFindJobService findAJobService;

        public FindAJobController(IFindJobService findAJobService)
        {
            if(findAJobService == null)
            {
                throw new ArgumentException("jobservice");
            }

            this.findAJobService = findAJobService;
        }

        // GET: FindAJob
        public ActionResult Index()
        {
            var jobs = this.findAJobService.GetJobs();
            return View(jobs);
        }

        [HttpPost]
        public ActionResult Index(JobIdViewModel model)
        {
            if (User.IsInRole("Employee"))
            {
                var id = Request["hidden"];
                var employee = User.Identity.GetUserId();
                var job = this.findAJobService.FindAJob(model.JobId);
                this.findAJobService.AddCandidate(employee, job);
            }

            //this.findAJobService
            return View();
        }

        public ActionResult Apply(string Id)
        {
            var jobId = new Guid(Id);
            var job = this.findAJobService.FindAJob(jobId);
            return View(job);
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
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}