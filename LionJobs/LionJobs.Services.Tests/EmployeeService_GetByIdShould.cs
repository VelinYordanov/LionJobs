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
    public class EmployeeService_GetByIdShould
    {
        [Test]
        public void ReturnEmployeeById()
        {
            //Arrange
            string test = "test";
            var mockedRepository = new Mock<IEfRepository<Employee>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();
            var employee = new Employee();
            mockedRepository.Setup(x => x.GetById(test)).Returns(employee);
            var service = new EmployeesService(mockedRepository.Object, mockedUnitOfWork.Object,mockedImageService.Object);

            //Act
            var result = service.GetEmployee(test);

            //Assert
            Assert.IsInstanceOf<Employee>(result);
            Assert.AreEqual(result, employee);
        }

        [Test]
        public void NotReturnEmployeeById_WhenWrongIdIsPassed()
        {
            //Arrange
            string test = "test";
            var mockedRepository = new Mock<IEfRepository<Employee>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();
            var employee = new Employee();
            mockedRepository.Setup(x => x.GetById(test)).Returns(employee);
            var service = new EmployeesService(mockedRepository.Object, mockedUnitOfWork.Object,mockedImageService.Object);

            //Act
            var result = service.GetEmployee("qwe");

            //Assert
            Assert.IsNull(result);
        }
    }
}
