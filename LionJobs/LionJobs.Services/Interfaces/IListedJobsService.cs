using LionJobs.Data.Common;
using LionJobs.Models;
using LionJobs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Services.Interfaces
{
    public interface IListedJobsService
    {
        IEnumerable<Job> GetJobs(object Id);

        ICollection<ListedJobsViewModel> MapJobs(IEnumerable<Job> jobs);

        Job GetJob(object Id);

        void RemoveUserFromJobs(Employee employee, Job job);
    }
}
