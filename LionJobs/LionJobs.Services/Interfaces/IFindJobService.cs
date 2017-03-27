using LionJobs.Models;
using LionJobs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Services.Interfaces
{
    public interface IFindJobService
    {
        IEnumerable<CompanyJobsViewModel> GetJobs();

        Job FindAJob(object id);

        void AddCandidate(object employeeId, Job job);
    }
}
