using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionJobs.Data.Common;
using LionJobs.Models;
using LionJobs.Services.Interfaces;

namespace LionJobs.Services.Tests
{
    [TestFixture]
    public class EmployeesService_ConstructorShould
    {
        [Test]
        public void ThrowWhenRepositoryIsNull()
        {
            //Arrange
            var mockedRepository = new Mock<IEfRepository<Employee>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new EmployeesService(null, mockedUnitOfWork.Object,mockedImageService.Object));

            //Assert
            Assert.That(ex.Message.Contains("repository"));
        }

        [Test]
        public void ThrowWhenUnitOfWorkIsNull()
        {
            //Arrange
            var mockedRepository = new Mock<IEfRepository<Employee>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new EmployeesService(mockedRepository.Object, null,mockedImageService.Object));

            //Assert
            Assert.That(ex.Message.Contains("unitofwork"));
        }

        [Test]
        public void ThrowWhenImageServiceIsNull()
        {
            //Arrange
            var mockedRepository = new Mock<IEfRepository<Employee>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new EmployeesService(mockedRepository.Object, mockedUnitOfWork.Object, null));

            //Assert
            Assert.That(ex.Message.Contains("imageservice"));
        }

        [Test]
        public void ReturnAnInstanceWithProperParameters()
        {
            //Arrange
            var mockedRepository = new Mock<IEfRepository<Employee>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();

            //Act
            var ex = new EmployeesService(mockedRepository.Object, mockedUnitOfWork.Object,mockedImageService.Object);

            //Assert
            Assert.IsInstanceOf<EmployeesService>(ex);
        }
    }

}
