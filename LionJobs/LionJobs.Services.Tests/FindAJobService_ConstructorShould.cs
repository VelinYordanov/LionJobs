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
    public class FindAJobService_ConstructorShould
    {
        [Test]
        public void ThrowWhenJobRepositoryIsNull()
        {
            //Arrange
            var mockedJob = new Mock<IEfRepository<Job>>();
            var mockedEmployees = new Mock<IEfRepository<Employee>>();
            var viewModel = new Mock<CompanyJobsViewModel>();
            var unit = new Mock<IUnitOfWork>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new FindAJobService(null, mockedEmployees.Object, viewModel.Object, unit.Object));

            Assert.That(ex.Message.Contains("job"));
        }

        [Test]
        public void ThrowWhenEmployeeRepositoryIsNull()
        {
            //Arrange
            var mockedJob = new Mock<IEfRepository<Job>>();
            var mockedEmployees = new Mock<IEfRepository<Employee>>();
            var viewModel = new Mock<CompanyJobsViewModel>();
            var unit = new Mock<IUnitOfWork>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new FindAJobService(mockedJob.Object, null, viewModel.Object, unit.Object));

            Assert.That(ex.Message.Contains("employee"));
        }

        [Test]
        public void ThrowWhenViewModelIsNull()
        {
            //Arrange
            var mockedJob = new Mock<IEfRepository<Job>>();
            var mockedEmployees = new Mock<IEfRepository<Employee>>();
            var viewModel = new Mock<CompanyJobsViewModel>();
            var unit = new Mock<IUnitOfWork>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new FindAJobService(mockedJob.Object, mockedEmployees.Object, null, unit.Object));

            Assert.That(ex.Message.Contains("viewmodel"));
        }

        [Test]
        public void ThrowWhenUnitOfWorkIsNull()
        {
            //Arrange
            var mockedJob = new Mock<IEfRepository<Job>>();
            var mockedEmployees = new Mock<IEfRepository<Employee>>();
            var viewModel = new Mock<CompanyJobsViewModel>();
            var unit = new Mock<IUnitOfWork>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new FindAJobService(mockedJob.Object, mockedEmployees.Object, viewModel.Object, null));

            Assert.That(ex.Message.Contains("unitofwork"));
        }

        [Test]
        public void ReturnAnInstanceWithProperParameters()
        {
            //Arrange
            var mockedJob = new Mock<IEfRepository<Job>>();
            var mockedEmployees = new Mock<IEfRepository<Employee>>();
            var viewModel = new Mock<CompanyJobsViewModel>();
            var unit = new Mock<IUnitOfWork>();

            //Act
            var service = new FindAJobService(mockedJob.Object, mockedEmployees.Object, viewModel.Object, unit.Object);

            Assert.IsInstanceOf<FindAJobService>(service);
        }
    }
}
