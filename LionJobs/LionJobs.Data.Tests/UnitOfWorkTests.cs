using LionJobs.Data;
using LionJobs.Data.Common;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Data.Tests
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        [Test]
        public void UnitOfWorkConstructor_ShouldCreateAnInstanceOfUnitOfWork()
        {
            // Arrange
            var mockedDbContext = new Mock<LionJobsDbContext>();

            // Act
            var unitOfWork = new EfUnitOfWork(mockedDbContext.Object);

            // Assert
            Assert.IsInstanceOf<EfUnitOfWork>(unitOfWork);
        }
    }
}
