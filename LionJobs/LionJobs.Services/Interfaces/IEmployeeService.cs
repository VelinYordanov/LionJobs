using LionJobs.Models;
using LionJobs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Services.Interfaces
{
    public interface IEmployeeService
    {
        IQueryable<Employee> GetEmployees();

        Employee GetEmployee(object Id);

        JobCandidateViewModel MapModel(string employeeId, Employee employee, Guid jobId);

        IEnumerable<IEmployeeListViewModel> GetEmployeesList();
    }
}
