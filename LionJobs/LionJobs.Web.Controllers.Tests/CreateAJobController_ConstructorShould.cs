using LionJobs.Services;
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
    public class CreateAJobController_ConstructorShould
    {
        [Test]
        public void ThrowWhenJobServiceIsNull()
        {
            //Arrange
            var jobService = new Mock<CreateAJobService>();
            var viewModel = new Mock<CreateAJobViewModel>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new CreateAJobController(null, viewModel.Object));

            //Assert
            Assert.That(ex.Message.Contains("job"));

        }

        [Test]
        public void ThrowWhenViewModelIsNull()
        {
            //Arrange
            var jobService = new Mock<ICreateAJobService>();
            var viewModel = new Mock<CreateAJobViewModel>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new CreateAJobController(jobService.Object, null));

            //Assert
            Assert.That(ex.Message.Contains("viewmodel"));
        }

        [Test]
        public void ReturnAnInstanceWithProperParameters()
        {
            //Arrange
            var jobService = new Mock<ICreateAJobService>();
            var viewModel = new Mock<CreateAJobViewModel>();

            //Act
            var controller = new CreateAJobController(jobService.Object, viewModel.Object);

            //Assert
            Assert.IsInstanceOf<CreateAJobController>(controller);

        }

    }
}
