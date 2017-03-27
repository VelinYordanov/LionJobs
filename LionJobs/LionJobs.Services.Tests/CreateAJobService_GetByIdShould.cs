using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionJobs.Data.Common;
using LionJobs.Models;

namespace LionJobs.Services.Tests
{
    [TestFixture]
    public class CreateAJobService_GetByIdShould
    {
        [Test]
        public void ShouldReturnACompany_WhenProperIdIsPassed()
        {
            //Arrange
            var guid = Guid.NewGuid();            
            var mockedRepository = new Mock<IEfRepository<Company>>();
            var company = new Company();
            mockedRepository.Setup(x => x.GetById(guid)).Returns(company);

            var mockedJobRepository = new Mock<IEfRepository<Job>>();
            var mockedJob = new Mock<Job>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var service = new CreateAJobService(mockedRepository.Object, mockedJobRepository.Object, mockedJob.Object, mockedUnitOfWork.Object);

            //Act
            var result = service.GetCompany(guid);

            //Assert
            Assert.IsInstanceOf<Company>(result);
            Assert.AreEqual(company, result);
        }

        [Test]
        public void ShouldNotReturnACompany_WhenBadIdIsPassed()
        {
            var guid = Guid.NewGuid();
            //Arrange
            var mockedRepository = new Mock<IEfRepository<Company>>();
            var company = new Company();
            mockedRepository.Setup(x => x.GetById(guid)).Returns(company);

            var mockedCompanyRepository = new Mock<IEfRepository<Company>>();
            var mockedJobRepository = new Mock<IEfRepository<Job>>();
            var mockedJob = new Mock<Job>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var service = new CreateAJobService(mockedCompanyRepository.Object, mockedJobRepository.Object, mockedJob.Object, mockedUnitOfWork.Object);

            //Act
            var result = service.GetCompany(Guid.NewGuid());

            //Assert
            Assert.IsNull(result);
        }
    }
}
