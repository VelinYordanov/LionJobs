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
    public class ListedJobsService : IListedJobsService
    {
        private IEfRepository<Job> jobsRepository;
        private IEfRepository<Company> companyRepository;

        public ListedJobsService(IEfRepository<Job> jobsRepository, IEfRepository<Company> companyRepository)
        {
            if(jobsRepository == null)
            {
                throw new ArgumentException("jobs");
            }

            if(companyRepository == null)
            {
                throw new ArgumentException("company");
            }

            this.jobsRepository = jobsRepository;
            this.companyRepository = companyRepository;
        }

        public IEnumerable<Job> GetJobs(object Id)
        {
            var company = this.companyRepository.GetById(Id);

            var listedJobs = this.jobsRepository.GetAll()
                .Where(x => x.Company.CompanyName == company.CompanyName && 
                x.Company.Description == company.Description);

            return listedJobs;
        }

        public ICollection<ListedJobsViewModel> MapJobs(IEnumerable<Job> jobs)
        {
            ICollection<ListedJobsViewModel> jobsDto = new List<ListedJobsViewModel>();
            foreach (var job in jobs)
            {
                jobsDto.Add(new ListedJobsViewModel
                {
                    Id = job.Id,
                    Name = job.Title,
                    Description = job.Description,
                    Candidates = job.JobApplicants
                });
            }

            return jobsDto;
        }

        public Job GetJob(object Id)
        {
            return this.jobsRepository.GetById(Id);
        }

        public void RemoveUserFromJobs(Employee employee,IUnitOfWork unitOfWork)
        {
            this.jobsRepository.GetAll().Where(x => x.JobApplicants.Contains(employee)).Select(x =>
              {
                  x.JobApplicants.Remove(employee);
                  return employee;
              });

            unitOfWork.SaveChanges();
        }
    }
}
