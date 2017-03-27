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
    public class CreateAJobService_ConstructorShould
    {
        [Test]
        public void ThrowWhenCompanyRepositoryIsNull()
        {
            //Arrange
            var mockedCompanyRepository = new Mock<IEfRepository<Company>>();
            var mockedJobRepository = new Mock<IEfRepository<Job>>();
            var mockedJob = new Mock<Job>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new CreateAJobService(null, mockedJobRepository.Object, mockedJob.Object, mockedUnitOfWork.Object));

            Assert.That(ex.Message.Contains("company repository null"));
        }

        [Test]
        public void ThrowWhenJobRepositoryIsNull()
        {
            //Arrange
            var mockedCompanyRepository = new Mock<IEfRepository<Company>>();
            var mockedJobRepository = new Mock<IEfRepository<Job>>();
            var mockedJob = new Mock<Job>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new CreateAJobService(mockedCompanyRepository.Object, null, mockedJob.Object, mockedUnitOfWork.Object));

            Assert.That(ex.Message.Contains("jobs repository null"));
        }

        [Test]
        public void ThrowWhenJobIsNull()
        {
            //Arrange
            var mockedCompanyRepository = new Mock<IEfRepository<Company>>();
            var mockedJobRepository = new Mock<IEfRepository<Job>>();
            var mockedJob = new Mock<Job>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new CreateAJobService(mockedCompanyRepository.Object, mockedJobRepository.Object, null, mockedUnitOfWork.Object));

            Assert.That(ex.Message.Contains("job is null"));
        }

        [Test]
        public void ThrowWhenUnitOfWorkIsNull()
        {
            //Arrange
            var mockedCompanyRepository = new Mock<IEfRepository<Company>>();
            var mockedJobRepository = new Mock<IEfRepository<Job>>();
            var mockedJob = new Mock<Job>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new CreateAJobService(mockedCompanyRepository.Object, mockedJobRepository.Object, mockedJob.Object, null));

            Assert.That(ex.Message.Contains("Unit of work is null"));
        }

        [Test]
        public void ReturnsAnInstanceWhenProperParametersArePassed()
        {
            //Arrange
            var mockedCompanyRepository = new Mock<IEfRepository<Company>>();
            var mockedJobRepository = new Mock<IEfRepository<Job>>();
            var mockedJob = new Mock<Job>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act
            var service = new CreateAJobService(mockedCompanyRepository.Object, mockedJobRepository.Object, mockedJob.Object, mockedUnitOfWork.Object);

            //Assert
            Assert.IsInstanceOf<CreateAJobService>(service);
        }
    }
}
