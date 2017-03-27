using NUnit.Framework;
using System;
using LionJobs.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionJobs.Data.Common;
using LionJobs.Models;
using Moq;

namespace LionJobs.Services.Tests
{
    [TestFixture]
    public class CompanyServiceTests
    {
        [Test]
        public void Constructor_ShouldThrowWhenRepositoryIsNull()
        {
            //Arrange,act,assert
           Assert.Throws<ArgumentException>(() => new CompaniesService(null));
        }

        [Test]
        public void Constructor_ShouldReturnAnInstanceOfCompaniesService()
        {
            //Arrange
            var mockedRepository = new Mock<IEfRepository<Company>>();

            //Act
            var service = new CompaniesService(mockedRepository.Object);

            //Assert
            Assert.IsInstanceOf<CompaniesService>(service);
        }

        [Test]
        public void GetCompanies_ShouldProperlyReturnAllCompanies()
        {
            //Arrange
            var mockedRepository = new Mock<IEfRepository<Company>>();
            var companies = new List<Company>()
            {
                new Company {CompanyName="Name",Description="Description" },
                new Company {CompanyName="Name",Description="Description" },
                new Company {CompanyName="Name",Description="Description" }
            };

            mockedRepository.Setup(x => x.GetAll()).Returns(companies);
            var service = new CompaniesService(mockedRepository.Object);

            //Act
            var result = service.GetCompanies();

            //Assert
            Assert.AreEqual(3, result.Count());
        }
    }
}
