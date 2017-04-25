using LionJobs.Data.Common;
using LionJobs.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Web.Controllers.Tests
{
    [TestFixture]
    public class ListedJobsController_ConstructorShould
    {
        [Test]
        public void ThrowWhenListedJobServiceIsNull()
        {
            //Arrange
            var mockedList = new Mock<IListedJobsService>();
            var mockedEmployee = new Mock<IEmployeeService>();
            var mockedUnit = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new ListedJobsController(null, mockedEmployee.Object, mockedUnit.Object,mockedImageService.Object));

            //Assert
            Assert.That(ex.Message.Contains("jobservice"));
        }

        [Test]
        public void ThrowWhenEmployeeServiceIsNull()
        {
            //Arrange
            var mockedList = new Mock<IListedJobsService>();
            var mockedEmployee = new Mock<IEmployeeService>();
            var mockedUnit = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new ListedJobsController(mockedList.Object, null, mockedUnit.Object,mockedImageService.Object));

            //Assert
            Assert.That(ex.Message.Contains("employeeservice"));
        }

        [Test]
        public void ThrowWhenUnitOfWorkIsNull()
        {
            //Arrange
            var mockedList = new Mock<IListedJobsService>();
            var mockedEmployee = new Mock<IEmployeeService>();
            var mockedUnit = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new ListedJobsController(mockedList.Object, mockedEmployee.Object, null,mockedImageService.Object));

            //Assert
            Assert.That(ex.Message.Contains("unitofwork"));
        }

        [Test]
        public void ThrowWhenImageServiceIsNull()
        {
            //Arrange
            var mockedList = new Mock<IListedJobsService>();
            var mockedEmployee = new Mock<IEmployeeService>();
            var mockedUnit = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new ListedJobsController(mockedList.Object, mockedEmployee.Object, mockedUnit.Object, null));

            //Assert
            Assert.That(ex.Message.Contains("imageservice"));
        }

        [Test]
        public void ReturnAnInstanceWithProperParameters()
        {
            //Arrange
            var mockedList = new Mock<IListedJobsService>();
            var mockedEmployee = new Mock<IEmployeeService>();
            var mockedUnit = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();

            //Act
            var controller = new ListedJobsController(mockedList.Object, mockedEmployee.Object, mockedUnit.Object,mockedImageService.Object);

            //Assert
            Assert.IsInstanceOf<ListedJobsController>(controller);
        }
    }
}
