using LionJobs.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace LionJobs.Web.ViewModels
{
    public class EmployeesListViewModel : IEmployeeListViewModel
    {
        public string FullName { get; set; }

        public string UserImageUrl { get; set; }
    }
}