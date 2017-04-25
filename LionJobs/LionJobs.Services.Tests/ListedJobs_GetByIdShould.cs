using LionJobs.Data.Common;
using LionJobs.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Services.Tests
{
    [TestFixture]
    public class ListedJobs_GetJob
    {
        [Test]
        public void ReturnAJob()
        {
            //Arrange
            string test = "test";
            var job = new Job();
            var mockedJobs = new Mock<IEfRepository<Job>>();
            var mockedCompany = new Mock<IEfRepository<Company>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var service = new ListedJobsService(mockedJobs.Object, mockedCompany.Object, mockedUnitOfWork.Object);
            mockedJobs.Setup(x => x.GetById(test)).Returns(job);

            //Assert
            var result = service.GetJob(test);

            //Assert
            Assert.IsInstanceOf<Job>(result);
        }

        [Test]
        public void NotReturnAJob_WhenBadIdIsPassed()
        {
            //Arrange
            string test = "test";
            var job = new Job();
            var mockedJobs = new Mock<IEfRepository<Job>>();
            var mockedCompany = new Mock<IEfRepository<Company>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var service = new ListedJobsService(mockedJobs.Object, mockedCompany.Object,mockedUnitOfWork.Object);
            mockedJobs.Setup(x => x.GetById(test)).Returns(job);

            //Assert
            var result = service.GetJob("qwe");

            //Assert
            Assert.IsNull(result);
        }
    }
}
