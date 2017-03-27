using LionJobs.Data.Common;
using LionJobs.Models;
using LionJobs.Services.Interfaces;
using LionJobs.ViewModels;
using System;
using System.Collections.Generic;

namespace LionJobs.Services
{
    public class EmployeesService : IEmployeeService
    {
        private IEfRepository<Employee> repository;
        private IUnitOfWork unitOfWork;

        public EmployeesService(IEfRepository<Employee> repository, IUnitOfWork unitOfWork)
        {
            if(repository == null)
            {
                throw new ArgumentException("repository");
            }

            if(unitOfWork == null)
            {
                throw new ArgumentException("unitofwork");
            }

            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return this.repository.GetAll();
        }

        public Employee GetEmployee(object Id)
        {
            return this.repository.GetById(Id);
        }

        public JobCandidateViewModel MapModel(string employeeId,Employee employee, Guid jobId)
        {
            var model = new JobCandidateViewModel
            {
                FullName = employee.FirstName + " " + employee.LastName,
                EmployeeId = employeeId,
                JobId = jobId
            };

            return model;
        }
    }
}
