using LionJobs.Services;
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
    public class AccountController_ConstructorShould
    {
        [Test]
        public void Throw_WhenImageServiceIsNull()
        {
            //Arrange
            var mockedImage = new Mock<ImageService>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new AccountController(null));

            //Assert
            Assert.That(ex.Message.Contains("image"));
        }

        [Test]
        public void ReturnAnInstanceWithProperParameters()
        {
            //Arrange
            var mockedImage = new Mock<ImageService>();

            //Act
            var controller = new AccountController(mockedImage.Object);

            //Assert
            Assert.IsInstanceOf<AccountController>(controller);
        }
    }
}
