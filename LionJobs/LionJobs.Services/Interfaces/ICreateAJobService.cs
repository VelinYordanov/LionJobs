using LionJobs.Models;
using LionJobs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Services.Interfaces
{
    public interface ICreateAJobService
    {
        Company GetCompany(Guid id);

        void AddJobToCompany(object companyId, Job job);

        Job MapJob(CreateAJobViewModel model);
    }
}
