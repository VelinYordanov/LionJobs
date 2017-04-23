using LionJobs.Data.Common;
using LionJobs.Models;
using LionJobs.Services.Interfaces;
using LionJobs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LionJobs.Services
{
    public class EmployeesService : IEmployeeService
    {
        private IEfRepository<Employee> repository;
        private IImageService imageService;
        private IUnitOfWork unitOfWork;

        public EmployeesService(IEfRepository<Employee> repository, IUnitOfWork unitOfWork, IImageService imageService)
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
            this.imageService = imageService;
        }

        public IQueryable<Employee> GetEmployees()
        {
            return this.repository.GetAllQueryable;
        }

        public IEnumerable<IEmployeeListViewModel> GetEmployeesList()
        {
            var employeesData = this.GetEmployees().Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.UserImage
            }).ToList();

            var employees = new List<IEmployeeListViewModel>();

            foreach (var item in employeesData)
            {
                var employee = new EmployeesListViewModel
                {
                    FullName = item.FirstName + " " + item.LastName,
                    UserImageUrl = this.imageService.ByteArrayToImageUrl(item.UserImage)
                };
                
                employees.Add(employee);
            }

            return employees;
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

        public ProfileEmployeeViewModel Employee2ProfileViewModel(Employee employee)
        {
            return new ProfileEmployeeViewModel
            {
                FullName = employee.FirstName + " " + employee.LastName,
                ImageUrl = this.imageService.ByteArrayToImageUrl(employee.UserImage)
            };
        }
    }
}
