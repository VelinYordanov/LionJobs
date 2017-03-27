using LionJobs.Data.Common;
using LionJobs.Models;
using LionJobs.Services.Interfaces;
using LionJobs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Services
{
    public class CreateAJobService :ICreateAJobService
    {
        private readonly IEfRepository<Company> companyRepository;
        private readonly IEfRepository<Job> jobsRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly Job job;

        public CreateAJobService(IEfRepository<Company> companyRepository, IEfRepository<Job> jobsRepository,Job job,IUnitOfWork unitOfWork)
        {
            if(companyRepository == null)
            {
                throw new ArgumentException("company repository null");
            }
            this.companyRepository = companyRepository;

            if(jobsRepository == null)
            {
                throw new ArgumentException("jobs repository null");
            }
            this.jobsRepository = jobsRepository;

            if(job == null)
            {
                throw new ArgumentException("job is null");
            }
            this.job = job;

            if(unitOfWork == null)
            {
                throw new ArgumentException("Unit of work is null");
            }
            this.unitOfWork = unitOfWork;
        }

        public Company GetCompany(Guid id)
        {
            return this.companyRepository.GetById(id);
        }

        public void AddJobToCompany(object companyId, Job job)
        {
            var company = this.companyRepository.GetById(companyId);
            job.Company = company;
            this.jobsRepository.Add(job);
            company.ListedJobs.Add(job);
            this.unitOfWork.SaveChanges();
        }

        public Job MapJob(CreateAJobViewModel model)
        {
            this.job.Title = model.Title;
            this.job.Description = model.Description;
            this.job.Tags = model.GetTags();
            return this.job;
        }
    }
}
