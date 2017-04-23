using LionJobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.ViewModels
{
    public class EmployeeHireViewModel
    {
        public string EmployeeId { get; set; }

        public string JobId { get; set; }

        public string FullName { get; set; }

        public ICollection<Job> JobHistory { get; set; }

        public byte[] Cv { get; set; }

        public string UserImage { get; set; }
    }
}
