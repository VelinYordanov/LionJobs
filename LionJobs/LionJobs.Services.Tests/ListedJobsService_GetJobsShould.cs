//using LionJobs.Data.Common;
//using LionJobs.Models;
//using Moq;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LionJobs.Services.Tests
//{
//    [TestFixture]
//    public class ListedJobsService_GetJobsShould
//    {
//        [Test]
//        public void ReturnJobs()
//        {
//            //Arrange
//            string test = "test";            
//            var mockedJobs = new Mock<IEfRepository<Job>>();
//            var mockedCompany = new Mock<IEfRepository<Company>>();
//            var jobs = new List<Job>()
//            {
//                new Job {Title="Title" }
//            };
//            var company = new Company { Id = test, ListedJobs = jobs };
//            mockedJobs.Setup(x => x.GetAll()).Returns(jobs);
//            mockedCompany.Setup(x => x.GetById(test)).Returns(company);         
//            var service = new ListedJobsService(mockedJobs.Object, mockedCompany.Object);

//            //Act
//            var result = service.GetJobs(test);

//            //Assert
//            Assert.AreEqual(1, result.Count());
//        }
//    }
//}
