﻿using LionJobs.Data.Common;
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

        public FindAJobService(IEfRepository<Job> jobRepository, IEfRepository<Employee> employeeRepository, PagedFindAJobList jobListModel,IUnitOfWork unitOfWork)
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

            this.jobRepository = jobRepository;
            this.employeeRepository = employeeRepository;
            this.jobListModel = jobListModel;
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
            job.JobApplicants.Add(user);
            this.unitOfWork.SaveChanges();
        }
    }
}
