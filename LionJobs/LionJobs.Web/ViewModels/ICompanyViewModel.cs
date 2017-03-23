using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LionJobs.Web.ViewModels
{
    public interface ICompanyViewModel
    {
        string CompanyName { get; set; }

        string Description { get; set; }

        string UserImageUrl { get; set; }
    }
}