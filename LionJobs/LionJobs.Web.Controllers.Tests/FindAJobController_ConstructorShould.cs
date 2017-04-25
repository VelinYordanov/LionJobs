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
        public void ThrowWhenFindAJobServiceIsNull()
        {
            //Arrange
            var mockedFindAJobService = new Mock<IFindJobService>();
            var mockedEmployeeService = new Mock<IEmployeeService>();
            var mockedCompanyService = new Mock<ICompanyService>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new FindAJobController(null, mockedEmployeeService.Object, mockedCompanyService.Object));

            //Assert
            Assert.That(ex.Message.Contains("jobservice"));
        }

        [Test]
        public void ThrowWhenEmployeeServiceIsNull()
        {
            //Arrange
            var mockedFindAJobService = new Mock<IFindJobService>();
            var mockedEmployeeService = new Mock<IEmployeeService>();
            var mockedCompanyService = new Mock<ICompanyService>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new FindAJobController(mockedFindAJobService.Object, null, mockedCompanyService.Object));

            //Assert
            Assert.That(ex.Message.Contains("employeeservice"));
        }

        [Test]
        public void ThrowWhenCompanyServiceIsNull()
        {
            //Arrange
            var mockedFindAJobService = new Mock<IFindJobService>();
            var mockedEmployeeService = new Mock<IEmployeeService>();
            var mockedCompanyService = new Mock<ICompanyService>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new FindAJobController(mockedFindAJobService.Object, mockedEmployeeService.Object, null));

            //Assert
            Assert.That(ex.Message.Contains("companyservice"));
        }

        [Test]
        public void ReturnAnInstanceWithProperParameters()
        {
            //Arrange
            var mockedFindAJobService = new Mock<IFindJobService>();
            var mockedEmployeeService = new Mock<IEmployeeService>();
            var mockedCompanyService = new Mock<ICompanyService>();

            //Act
            var controller = new FindAJobController(mockedFindAJobService.Object,mockedEmployeeService.Object,mockedCompanyService.Object);

            //Assert
            Assert.IsInstanceOf<FindAJobController>(controller);
        }
    }
}
