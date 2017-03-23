using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LionJobs.Web.ViewModels
{
    public class CompanyViewModel :ICompanyViewModel
    {
        public string CompanyName { get; set; }

        public string Description { get; set; }

        public string UserImageUrl { get; set; }        
    }
}