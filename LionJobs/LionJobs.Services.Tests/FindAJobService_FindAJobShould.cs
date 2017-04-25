using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionJobs.Data.Common;
using LionJobs.Models;
using LionJobs.ViewModels;
using LionJobs.Services.Interfaces;

namespace LionJobs.Services.Tests
{
    [TestFixture]
    public class FindAJobService_FindAJobShould
    {
        [Test]
        public void ReturnAJob()
        {
            //Arrange
            string test = "test";
            var job = new Job();
            var mockedJob = new Mock<IEfRepository<Job>>();
            var mockedEmployees = new Mock<IEfRepository<Employee>>();
            var viewModel = new Mock<PagedFindAJobList>();
            var unit = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();
            mockedJob.Setup(x => x.GetById(test)).Returns(job);
            var service = new FindAJobService(mockedJob.Object, mockedEmployees.Object, viewModel.Object, unit.Object,mockedImageService.Object);

            //Act
            var result = service.FindAJob(test);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, job);
        }

        [Test]
        public void NotReturnAJob_WhenBadIdIsPassed()
        {
            //Arrange
            string test = "test";
            var job = new Job();
            var mockedJob = new Mock<IEfRepository<Job>>();
            var mockedEmployees = new Mock<IEfRepository<Employee>>();
            var viewModel = new Mock<PagedFindAJobList>();
            var unit = new Mock<IUnitOfWork>();
            var mockedImageService = new Mock<IImageService>();
            mockedJob.Setup(x => x.GetById(test)).Returns(job);
            var service = new FindAJobService(mockedJob.Object, mockedEmployees.Object, viewModel.Object, unit.Object,mockedImageService.Object);

            //Act
            var result = service.FindAJob("qwe");

            //Assert
            Assert.IsNull(result);
        }
    }
}
