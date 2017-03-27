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
    public class CompaniesController_ConstructorShould
    {
        [Test]
        public void ThrowWhenCompanyServiceIsNull()
        {
            //Arrange
            var service = new Mock<ICompanyService>();
            var viewModel = new Mock<ICompanyViewModel>();
            var imageService = new Mock<IImageService>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new CompaniesController(null, imageService.Object, viewModel.Object));

            //Assert
            Assert.That(ex.Message.Contains("company"));
        }

        [Test]
        public void ThrowWhenImageServiceIsNull()
        {
            //Arrange
            var service = new Mock<ICompanyService>();
            var viewModel = new Mock<ICompanyViewModel>();
            var imageService = new Mock<IImageService>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new CompaniesController(service.Object, null, viewModel.Object));

            //Assert
            Assert.That(ex.Message.Contains("image"));
        }

        [Test]
        public void ThrowWhenViewModelIsNull()
        {
            //Arrange
            var service = new Mock<ICompanyService>();
            var viewModel = new Mock<ICompanyViewModel>();
            var imageService = new Mock<IImageService>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new CompaniesController(service.Object, imageService.Object, null));

            //Assert
            Assert.That(ex.Message.Contains("viewmodel"));
        }

        [Test]
        public void ReturnAnInstanceWhenProperParametersArePassed()
        {
            //Arrange
            var service = new Mock<ICompanyService>();
            var viewModel = new Mock<ICompanyViewModel>();
            var imageService = new Mock<IImageService>();

            //Act
            var controller = new CompaniesController(service.Object, imageService.Object, viewModel.Object);

            //Assert
            Assert.IsInstanceOf<CompaniesController>(controller);
        }
    }
}
