using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.ViewModels
{
    public class PagedFindAJobList
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<CompanyJobsViewModel> Jobs { get; set; }
    }
}
