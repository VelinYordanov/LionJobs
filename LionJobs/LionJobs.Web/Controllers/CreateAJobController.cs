using LionJobs.Services;
using LionJobs.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LionJobs.Web.Controllers
{
    public class CreateAJobController : Controller
    {
        private readonly CreateAJobService jobService;
        private readonly CreateAJobViewModel jobViewModel;

        public CreateAJobController(CreateAJobService jobService,CreateAJobViewModel jobViewModel)
        {
            this.jobService = jobService;
            this.jobViewModel = jobViewModel;
        }
        // GET: CreateAJob
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CreateAJobViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var job = this.jobService.MapJob(model);
                    var company = User.Identity.GetUserId();
                    this.jobService.AddJobToCompany(company, job);
                    return RedirectToAction("Index", "Home");
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                       var asd = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            var qwe = string.Format("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                }               
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

    }
}