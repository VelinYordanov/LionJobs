using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.ViewModels
{
    public class PagedCompanyViewModelList
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<CompanyViewModel> Companies { get; set; }
    }
}
