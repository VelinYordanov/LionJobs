﻿using LionJobs.Data.Common;
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
    public class ListedJobsService_ConstructorShould
    {
        [Test]
        public void ThrowWhenJobRepositoryIsNull()
        {
            //Arrange
            var mockedJobs = new Mock<IEfRepository<Job>>();
            var mockedCompany = new Mock<IEfRepository<Company>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new ListedJobsService(null, mockedCompany.Object, mockedUnitOfWork.Object));

            //Assert
            Assert.That(ex.Message.Contains("jobs"));
        }

        [Test]
        public void ThrowWhenCompanyRepositoryIsNull()
        {
            //Arrange
            var mockedJobs = new Mock<IEfRepository<Job>>();
            var mockedCompany = new Mock<IEfRepository<Company>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new ListedJobsService(mockedJobs.Object, null, mockedUnitOfWork.Object));

            //Assert
            Assert.That(ex.Message.Contains("company"));
        }

        [Test]
        public void ThrowWhenUnitOfWorkIsNull()
        {
            //Arrange
            var mockedJobs = new Mock<IEfRepository<Job>>();
            var mockedCompany = new Mock<IEfRepository<Company>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new ListedJobsService(mockedJobs.Object, mockedCompany.Object, null));

            //Assert
            Assert.That(ex.Message.Contains("unitofwork"));
        }

        [Test]
        public void ReturnAnInstanceWithProperParameters()
        {
            //Arrange
            var mockedJobs = new Mock<IEfRepository<Job>>();
            var mockedCompany = new Mock<IEfRepository<Company>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act
            var service = new ListedJobsService(mockedJobs.Object, mockedCompany.Object,mockedUnitOfWork.Object);

            //Assert
            Assert.IsInstanceOf<ListedJobsService>(service);
        }
    }
}
