﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LionJobs.ViewModels
{
    public class CompanyViewModel : ICompanyViewModel
    {
        public string CompanyName { get; set; }

        public string Description { get; set; }

        public string UserImageUrl { get; set; }

        public byte[] UserImage { get; set; }
    }
}