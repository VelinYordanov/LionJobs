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
    public class EmployeeService_GetAllShould
    {
        [Test]
        public void ShouldReturnAll()
        {
            //Arrange
            var mockedRepository = new Mock<IEfRepository<Employee>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var employees = new List<Employee>()
            {
                new Employee {FirstName="qweqwe" }
            };

            mockedRepository.Setup(x => x.GetAll()).Returns(employees);
            var service = new EmployeesService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act
            var result = service.GetEmployees();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());            
        }

        [Test]
        public void ShouldReturnEmptyListWhenNoEmployees()
        {
            //Arrange
            var mockedRepository = new Mock<IEfRepository<Employee>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var employees = new List<Employee>();

            mockedRepository.Setup(x => x.GetAll()).Returns(employees);
            var service = new EmployeesService(mockedRepository.Object, mockedUnitOfWork.Object);

            //Act
            var result = service.GetEmployees();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }
    }
}
