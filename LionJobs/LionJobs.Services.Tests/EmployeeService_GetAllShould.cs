using LionJobs.Data.Common;
using LionJobs.Models;
using LionJobs.Services.Interfaces;
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
            var mockedImageService = new Mock<IImageService>();
            var employees = new List<Employee>()
            {
                new Employee {FirstName="qweqwe" }
            }.AsQueryable();

            mockedRepository.Setup(x => x.GetAllQueryable).Returns(employees);
            var service = new EmployeesService(mockedRepository.Object, mockedUnitOfWork.Object,mockedImageService.Object);

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
            var mockedImageService = new Mock<IImageService>();
            var employees = new List<Employee>();

            mockedRepository.Setup(x => x.GetAll()).Returns(employees);
            var service = new EmployeesService(mockedRepository.Object, mockedUnitOfWork.Object,mockedImageService.Object);

            //Act
            var result = service.GetEmployees();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }
    }
}
