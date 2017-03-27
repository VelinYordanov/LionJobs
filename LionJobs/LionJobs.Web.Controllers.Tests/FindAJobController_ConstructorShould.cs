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
    public class FindAJobController_ConstructorShould
    {
        [Test]
        public void ThrowWhenServiceIsNull()
        {
            //Arrange
            var mockedService = new Mock<IFindJobService>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new FindAJobController(null));

            //Assert
            Assert.That(ex.Message.Contains("jobservice"));
        }

        [Test]
        public void ReturnAnInstanceWithProperParameters()
        {
            //Arrange
            var mockedService = new Mock<IFindJobService>();

            //Act
            var controller = new FindAJobController(mockedService.Object);

            //Assert
            Assert.IsInstanceOf<FindAJobController>(controller);
        }
    }
}
