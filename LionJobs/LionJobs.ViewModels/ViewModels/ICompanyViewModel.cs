using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LionJobs.ViewModels
{
    public interface ICompanyViewModel
    {
        string CompanyName { get; set; }

        string Description { get; set; }

        string UserImageUrl { get; set; }

        byte[] UserImage { get; set; }
    }
}