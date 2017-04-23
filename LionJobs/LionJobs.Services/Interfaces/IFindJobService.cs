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
        PagedFindAJobList GetJobs(int id);

        Job FindAJob(object id);

        void AddCandidate(object employeeId, Job job);

        JobDescriptionViewModel GetJobDescriptionModel(Company company, Job job);

         Company GetJobCompany(Guid id);
    }
}
