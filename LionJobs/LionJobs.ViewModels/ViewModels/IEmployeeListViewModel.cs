using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace LionJobs.ViewModels
{
    public interface IEmployeeListViewModel
    {
        string FullName { get; set; }

        string UserImageUrl { get; set; }
    }
}