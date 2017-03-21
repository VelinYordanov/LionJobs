using LionJobs.Data.Common;
using LionJobs.Models;
using LionJobs.Services.Interfaces;
using System.Collections.Generic;

namespace LionJobs.Services
{
    public class EmployeesService : IEmployeeService
    {
        private IEfRepository<Employee> repository;
        private EfUnitOfWork unitOfWork;

        public EmployeesService(IEfRepository<Employee> repository, EfUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return this.repository.GetAll();
        }
    }
}
