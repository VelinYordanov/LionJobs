using LionJobs.Data.Common;
using LionJobs.Models;
using LionJobs.ViewModels;
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
    public class CreateAJobService_MapJobShould
    {
        [Test]
        public void MapJobProperly()
        {
            //Arrange
            var company = new Company();
            var tags = new List<Tag>();
            var createAJobViewModel = new CreateAJobViewModel()
            {
                Description = "Description",
                Title = "Title"
            };

            var mockedCompanyRepository = new Mock<IEfRepository<Company>>();
            var mockedJobRepository = new Mock<IEfRepository<Job>>();
            var mockedJob = new Mock<Job>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var service = new CreateAJobService(mockedCompanyRepository.Object, mockedJobRepository.Object, mockedJob.Object, mockedUnitOfWork.Object);

            //Act
            var mapped = service.MapJob(createAJobViewModel);

            //Assert
            Assert.AreEqual(createAJobViewModel.Title, "Title");
            Assert.AreEqual(createAJobViewModel.Description, "Description");            
        }

    }
}
