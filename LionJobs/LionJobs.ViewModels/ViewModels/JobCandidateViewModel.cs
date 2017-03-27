using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.ViewModels
{
    public class JobCandidateViewModel
    {
        public string EmployeeId { get; set; }

        public Guid JobId { get; set; }

        public string FullName { get; set; }
    }
}
