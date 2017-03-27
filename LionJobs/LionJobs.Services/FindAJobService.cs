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
    public class FindAJobService : IFindJobService
    {
        private IEfRepository<Job> jobRepository;
        private IEfRepository<Employee> employeeRepository;
        private CompanyJobsViewModel jobsViewModel;
        private IUnitOfWork unitOfWork;

        public FindAJobService(IEfRepository<Job> jobRepository, IEfRepository<Employee> employeeRepository, CompanyJobsViewModel jobsViewModel,IUnitOfWork unitOfWork)
        {
            this.jobRepository = jobRepository;
            this.employeeRepository = employeeRepository;
            this.jobsViewModel = jobsViewModel;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<CompanyJobsViewModel> GetJobs()
        {
            return this.jobRepository.GetAll().Select(x =>
            {
                this.jobsViewModel.Id = x.Id;
                this.jobsViewModel.Title = x.Title;
                this.jobsViewModel.Description = x.Description;
                this.jobsViewModel.Tags = x.Tags;
                return this.jobsViewModel;
            });
        }

        public Job FindAJob(object id)
        {
            return this.jobRepository.GetById(id);
        }

        public void AddCandidate(object employeeId,Job job)
        {
            var user = this.employeeRepository.GetById(employeeId);
            job.JobApplicants.Add(user);
            this.unitOfWork.SaveChanges();
        }
    }
}
