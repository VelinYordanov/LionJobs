﻿using LionJobs.Services.Interfaces;
using LionJobs.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LionJobs.Web.Controllers
{
    public class CompaniesController : Controller
    {
        private ICompanyService companyService;
        private ICompanyViewModel companyViewModel;
        private IImageService imageService;

        public CompaniesController(ICompanyService companyService, IImageService imageService,ICompanyViewModel companyViewModel)
        {
            this.companyService = companyService;
            this.imageService = imageService;
            this.companyViewModel = companyViewModel;
        }

        // GET: Companies
        public ActionResult Index()
        {
            var companies = this.companyService.GetCompanies().Select(x =>
            {
                this.companyViewModel.CompanyName = x.CompanyName;
                this.companyViewModel.Description = x.Description;
                this.companyViewModel.UserImageUrl = this.imageService.ByteArrayToImageUrl(x.UserImage);
                return companyViewModel;
            });

            return View(companies);
        }
    }
}