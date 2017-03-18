using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Models.Tests
{
    [TestFixture]
    public class TagTests
    {
        [Test]
        public void TagConstructor_ShouldReturnAnInstanceOfTag()
        {
            //Arrange, Act
            var tag = new Tag();

            //Assert
            Assert.IsInstanceOf<Tag>(tag);
        }

        [Test]
        public void TagConstuctor_ShouldReturnAnObjectWithProperProperties()
        {
            //Arrange
            var guid = Guid.NewGuid();
            var jobs = new HashSet<Job>();
            var tagType = TagType.Android;

            //Act
            var tag = new Tag
            {
                Id = guid,
                Jobs = jobs,
                TagText = tagType
            };

            //Assert
            Assert.AreEqual(tag.Id, guid);
            Assert.AreEqual(tag.TagText, tagType);
            Assert.IsNotNull(tag.Jobs);
        }

        [Test]
        public void TagConstructor_ShouldHaveJobsVirtualProperty()
        {
            //Arrange
            var tag = new Tag();

            //Act
            var isVirtual = tag.GetType().GetProperty("Jobs").GetGetMethod().IsVirtual;

            //Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
