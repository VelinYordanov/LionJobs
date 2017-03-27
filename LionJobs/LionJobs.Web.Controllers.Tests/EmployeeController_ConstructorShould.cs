using LionJobs.Services.Interfaces;
using LionJobs.ViewModels;
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
    public class EmployeeController_ConstructorShould
    {
        [Test]
        public void ShouldThrowWhenEmployeeServiceIsNull()
        {
            //Arrange
            var mockedEmployee = new Mock<IEmployeeService>();
            var mockedModel = new Mock<IEmployeeListViewModel>();
            var mockedImage = new Mock<IImageService>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new EmployeesController(null, mockedImage.Object, mockedModel.Object));

            //Assert
            Assert.That(ex.Message.Contains("employee"));
        }

        [Test]
        public void ShouldThrowWhenImageServiceIsNull()
        {
            //Arrange
            var mockedEmployee = new Mock<IEmployeeService>();
            var mockedModel = new Mock<IEmployeeListViewModel>();
            var mockedImage = new Mock<IImageService>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new EmployeesController(mockedEmployee.Object, null, mockedModel.Object));

            //Assert
            Assert.That(ex.Message.Contains("image"));
        }

        [Test]
        public void ShouldThrowWhenViewModelIsNull()
        {
            //Arrange
            var mockedEmployee = new Mock<IEmployeeService>();
            var mockedModel = new Mock<IEmployeeListViewModel>();
            var mockedImage = new Mock<IImageService>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new EmployeesController(mockedEmployee.Object, mockedImage.Object, null));

            //Assert
            Assert.That(ex.Message.Contains("viewmodel"));
        }

        [Test]
        public void ReturnInstanceWithProperParameters()
        {
            //Arrange
            var mockedEmployee = new Mock<IEmployeeService>();
            var mockedModel = new Mock<IEmployeeListViewModel>();
            var mockedImage = new Mock<IImageService>();

            //Act
            var controller = new EmployeesController(mockedEmployee.Object, mockedImage.Object, mockedModel.Object);

            //Assert
            Assert.IsInstanceOf<EmployeesController>(controller);
        }
    }
}
