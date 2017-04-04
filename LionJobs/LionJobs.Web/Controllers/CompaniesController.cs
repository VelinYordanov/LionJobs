using LionJobs.Services.Interfaces;
using LionJobs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LionJobs.Web.Controllers
{
    [Authorize(Roles = "Employee")]
    public class CompaniesController : Controller
    {        
        private ICompanyService companyService;
        private ICompanyViewModel companyViewModel;
        private IImageService imageService;

        public CompaniesController(ICompanyService companyService, IImageService imageService, ICompanyViewModel companyViewModel)
        {
            if (companyService == null)
            {
                throw new ArgumentException("company");
            }

            if (imageService == null)
            {
                throw new ArgumentException("image");
            }

            if (companyViewModel == null)
            {
                throw new ArgumentException("viewmodel");
            }

            this.companyService = companyService;
            this.imageService = imageService;
            this.companyViewModel = companyViewModel;
        }

        // GET: Companies
        //[OutputCache(Duration =5*60)]
        public ActionResult Index(int id = 1)
        {
            var listedCompanies = this.companyService.GetPagedCompanies(id);

            return View(listedCompanies);
        }
    }
}