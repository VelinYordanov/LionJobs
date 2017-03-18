using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LionJobs.Models.Tests
{
    [TestFixture]
    public class JobTests
    {
        [Test]
        public void JobConstructor_ShouldReturnAJobInstance()
        {
            //Arrange,Act
            var job = new Job();
            //Assert
            Assert.IsInstanceOf<Job>(job);
        }

        [Test]
        public void JobConstructor_ShouldReturnAnObjectWithProperProperties()
        {
            //Arrange
            var guid = Guid.NewGuid();
            var title = "title";
            var description = "description";
            var employees = new HashSet<Employee>();
            var company = new Company();
            var tags = new HashSet<Tag>();

            //Act
            var job = new Job
            {
                Id = guid,
                Title = title,
                Description = description,
                JobApplicants = employees,
                Tags = tags,
                Company=company
            };

            //Assert
            Assert.AreEqual(job.Id, guid);
            Assert.AreEqual(job.Title, title);
            Assert.AreEqual(job.Description, description);
            Assert.IsNotNull(job.Company);
            Assert.IsNotNull(job.JobApplicants);
            Assert.IsNotNull(job.Tags);
        }

        [Test]
        public void JobConstructor_ShouldHaveJobApplicantsVirtualProperty()
        {
            //Arrange
            var job = new Job();

            //Act
            var isVirtual = job.GetType().GetProperty("JobApplicants").GetGetMethod().IsVirtual;

            //Act
            Assert.IsTrue(isVirtual);
        }

        [Test]
        public void JobConstructor_ShouldHaveCompanyVirtualProperty()
        {
            //Arrange
            var job = new Job();

            //Act
            var isVirtual = job.GetType().GetProperty("Company").GetGetMethod().IsVirtual;

            //Act
            Assert.IsTrue(isVirtual);
        }

        [Test]
        public void JobConstructor_ShouldHaveTagsVirtualProperty()
        {
            //Arrange
            var job = new Job();

            //Act
            var isVirtual = job.GetType().GetProperty("Tags").GetGetMethod().IsVirtual;

            //Act
            Assert.IsTrue(isVirtual);
        }

        [Test]
        public void JobConstructor_ShouldHaveRequiredAttributeToTitle()
        {
            // Arrange
            var job = new Job();
            var property = job.GetType().GetProperty("Title");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(RequiredAttribute));

            // Assert
            Assert.IsTrue(isDefined);

        }

        [Test]
        public void JobConstructor_ShouldHaveMinLengthAttributeToTitle()
        {
            // Arrange
            var job = new Job();
            var property = job.GetType().GetProperty("Title");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(MinLengthAttribute));

            // Assert
            Assert.IsTrue(isDefined);
        }

        [Test]
        public void JobConstructor_ShouldHaveMaxLengthAttributeToTitle()
        {
            //Arrange
            var job = new Job();
            var property = job.GetType().GetProperty("Title");

            //Act
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            //Assert
            Assert.IsTrue(isDefined);
        }

        [Test]
        public void JobConstructor_ShouldHaveRequiredAttributeToDescription()
        {
            // Arrange
            var job = new Job();
            var property = job.GetType().GetProperty("Description");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(RequiredAttribute));

            // Assert
            Assert.IsTrue(isDefined);

        }

        [Test]
        public void JobConstructor_ShouldHaveMinLengthAttributeToDescription()
        {
            // Arrange
            var job = new Job();
            var property = job.GetType().GetProperty("Description");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(MinLengthAttribute));

            // Assert
            Assert.IsTrue(isDefined);
        }

        [Test]
        public void JobConstructor_ShouldHaveMaxLengthAttributeToDescription()
        {
            //Arrange
            var job = new Job();
            var property = job.GetType().GetProperty("Description");

            //Act
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            //Assert
            Assert.IsTrue(isDefined);
        }
    }
}
