using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Models.Tests
{
    [TestFixture]
    public class CompanyTests
    {
        [Test]
        public void CompanyConstructor_ShouldReturnACompanyInstance()
        {
            //Arrange, Act
            var company = new Company();

            //Assert
            Assert.IsInstanceOf<Company>(company);
        }

        [Test]
        public void CompanyConstructor_ShouldReturnAnObjectWithProperProperties()
        {
            //Arrange
            var companyName = "companyName";
            var description = "asdasdasdasdasdassdassdasdassddassdasddassd";
            var jobs = new HashSet<Job>();

            //Act
            var company = new Company
            {
                CompanyName = companyName,
                Description = description,
                ListedJobs = jobs
            };

            //Assert
            Assert.AreEqual(company.CompanyName, companyName);
            Assert.AreEqual(company.Description, description);
            Assert.IsNotNull(company.ListedJobs);
        }

        [Test]
        public void CompanyConstructor_ShouldHaveListedJobsVirtualProperty()
        {
            //Arrange
            var company = new Company();

            //Act
            var isVirtual = company.GetType().GetProperty("ListedJobs").GetGetMethod().IsVirtual;

            //Assert
            Assert.IsTrue(isVirtual);
        }

        [Test]
        public void CompanyConstructor_ShouldHaveRequiredAttributeToCompanyName()
        {
            // Arrange
            var company = new Company();
            var property = company.GetType().GetProperty("CompanyName");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(RequiredAttribute));

            // Assert
            Assert.IsTrue(isDefined);

        }

        [Test]
        public void CompanyConstructor_ShouldHaveMinLengthAttributeToCompanyName()
        {
            // Arrange
            var company = new Company();
            var property = company.GetType().GetProperty("CompanyName");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(MinLengthAttribute));

            // Assert
            Assert.IsTrue(isDefined);
        }

        [Test]
        public void CompanyConstructor_ShouldHaveMaxLengthAttributeToCompanyName()
        {
            //Arrange
            var company = new Company();
            var property = company.GetType().GetProperty("CompanyName");

            //Act
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            //Assert
            Assert.IsTrue(isDefined);
        }
    }
}
