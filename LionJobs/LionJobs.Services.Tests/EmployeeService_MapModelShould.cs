using LionJobs.Data.Common;
using LionJobs.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Services.Tests
{
    [TestFixture]
    public class EmployeeService_MapModelShould
    {
        [Test]
        public void MapProperly()
        {
            //Arrange
            var mockedRepository = new Mock<IEfRepository<Employee>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var service = new EmployeesService(mockedRepository.Object, mockedUnitOfWork.Object);
            var firstString = "test";
            var employee = new Employee
            {
                FirstName = "asd",
                LastName = "asd"
            };

            var guid = Guid.NewGuid();

            //Act
           var jobcandidateViewModel = service.MapModel(firstString, employee, guid);

            //Assert
            Assert.AreEqual(jobcandidateViewModel.EmployeeId, firstString);
            Assert.AreEqual(jobcandidateViewModel.JobId, guid);
            Assert.AreEqual(jobcandidateViewModel.FullName, employee.FirstName + " " + employee.LastName);
        }
    }
}
