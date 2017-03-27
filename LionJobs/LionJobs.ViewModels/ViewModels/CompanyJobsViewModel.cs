using LionJobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.ViewModels
{
    public class CompanyJobsViewModel
    {
        public object Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
