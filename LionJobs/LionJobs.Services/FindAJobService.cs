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
        private const int pageSize = 3;
        private IEfRepository<Job> jobRepository;
        private IEfRepository<Employee> employeeRepository;
        private PagedFindAJobList jobListModel;
        private IUnitOfWork unitOfWork;
        private IImageService imageService;

        public FindAJobService(IEfRepository<Job> jobRepository, IEfRepository<Employee> employeeRepository, PagedFindAJobList jobListModel,IUnitOfWork unitOfWork,IImageService imageService)
        {
            if(jobRepository == null)
            {
                throw new ArgumentException("jobrepository");
            }

            if(employeeRepository == null)
            {
                throw new ArgumentException("employeerepository");
            }

            if(unitOfWork == null)
            {
                throw new ArgumentException("unitofwork");
            }

            if(jobListModel == null)
            {
                throw new ArgumentException("viewmodel");
            }

            if(imageService == null)
            {
                throw new ArgumentException("imageservice");
            }

            this.jobRepository = jobRepository;
            this.employeeRepository = employeeRepository;
            this.jobListModel = jobListModel;
            this.imageService = imageService;
            this.unitOfWork = unitOfWork;
        }

        public PagedFindAJobList GetJobs(int id)
        {
            var page = id;
            var allJobs = this.jobRepository.GetAllQueryable.Count();
            var allPages = (int)Math.Ceiling(allJobs / (decimal)pageSize);
            var jobsData =  this.jobRepository.GetAllQueryable.Select(x => new
            {
                x.Id,
                x.Title,
                x.Description,
                x.Tags
            }).OrderBy(x=>x.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();


            var jobs = new List<CompanyJobsViewModel>();

            foreach (var job in jobsData)
            {
                var jobsViewModel = new CompanyJobsViewModel();
                jobsViewModel.Id = job.Id;
                jobsViewModel.Title = job.Title;
                jobsViewModel.Description = job.Description;
                jobsViewModel.Tags = job.Tags;
                jobs.Add(jobsViewModel);
            }

            this.jobListModel.CurrentPage = page;
            this.jobListModel.TotalPages = allPages;
            this.jobListModel.Jobs = jobs;

            return jobListModel;
        }

        public Job FindAJob(object id)
        {
            return this.jobRepository.GetById(id);
        }

        public void AddCandidate(object employeeId,Job job)
        {
            var user = this.employeeRepository.GetById(employeeId);
            user.JobApplications.Add(job);
            job.JobApplicants.Add(user);
            this.unitOfWork.SaveChanges();
        }

        public JobDescriptionViewModel GetJobDescriptionModel(Company company,Job job)
        {
            return new JobDescriptionViewModel
            {
                CompanyImage = this.imageService.ByteArrayToImageUrl(company.UserImage),
                CompanyName = company.CompanyName,
                Id = job.Id,
                Description = job.Description,
                Title = job.Title
            };
        }

        public Company GetJobCompany(Guid id)
        {
            return this.jobRepository.GetAllQueryable.Where(x => x.Id == id).Select(x => x.Company).FirstOrDefault();
        }
    }
}
