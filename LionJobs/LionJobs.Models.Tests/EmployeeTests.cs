using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace LionJobs.Models.Tests
{
    [TestFixture]
    public class EmployeeTests
    {
        [Test]
        public void EmployeeConstructor_ShouldReturnAnEmployeeInstance()
        {
            var employee = new Employee();

            Assert.IsInstanceOf<Employee>(employee);
        }

        [Test]
        public void EmployeeConstructor_ShouldReturnAnObjectWithProperProperties()
        {
            //Arrange
            var firstName = "firstname";
            var secondName = "secondName";
            byte[] cv = new byte[] { 1, 2, 3 };
            var jobs = new HashSet<Job>();

            //Act
            var employee = new Employee()
            {
                FirstName = firstName,
                LastName = secondName,
                Cv = cv,
                JobHistory = jobs
            };

            //Assert
            Assert.AreEqual(employee.FirstName, firstName);
            Assert.AreEqual(employee.LastName, secondName);
            Assert.AreEqual(employee.Cv, cv);
            Assert.IsNotNull(employee.JobHistory);
        }

        [Test]
        public void EmployeeConstrcutor_ShouldHaveVirtualJobHistory()
        {
            //Arrange
            var employee = new Employee();

            //Act
            var isVirtual = employee.GetType().GetProperty("JobHistory").GetGetMethod().IsVirtual;

            //Assert
            Assert.IsTrue(isVirtual);

        }

        [Test]
        public void EmployeeConstructor_ShouldHaveRequiredAttributeToFirstName()
        {
            // Arrange
            var employee = new Employee();
            var property = employee.GetType().GetProperty("FirstName");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(RequiredAttribute));

            // Assert
            Assert.IsTrue(isDefined);

        }

        [Test]
        public void EmployeeConstructor_ShouldHaveMinLengthAttributeToFirstName()
        {
            // Arrange
            var employee = new Employee();
            var property = employee.GetType().GetProperty("FirstName");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(MinLengthAttribute));

            // Assert
            Assert.IsTrue(isDefined);
        }

        [Test]
        public void EmployeeConstructor_ShouldHaveMaxLengthAttributeToFirstName()
        {
            //Arrange
            var employee = new Employee();
            var property = employee.GetType().GetProperty("FirstName");

            //Act
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            //Assert
            Assert.IsTrue(isDefined);
        }

        [Test]
        public void EmployeeConstructor_ShouldHaveRequiredAttributeToLastName()
        {
            // Arrange
            var employee = new Employee();
            var property = employee.GetType().GetProperty("LastName");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(RequiredAttribute));

            // Assert
            Assert.IsTrue(isDefined);

        }

        [Test]
        public void EmployeeConstructor_ShouldHaveMinLengthAttributeToLastName()
        {
            // Arrange
            var employee = new Employee();
            var property = employee.GetType().GetProperty("LastName");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(MinLengthAttribute));

            // Assert
            Assert.IsTrue(isDefined);
        }

        [Test]
        public void EmployeeConstructor_ShouldHaveMaxLengthAttributeToLastName()
        {
            //Arrange
            var employee = new Employee();
            var property = employee.GetType().GetProperty("LastName");

            //Act
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            //Assert
            Assert.IsTrue(isDefined);
        }
    }
}
