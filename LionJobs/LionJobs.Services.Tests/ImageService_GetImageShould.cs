using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionJobs.Services.Tests
{
    [TestFixture]
    public class ImageService_GetImageShould
    {
        [Test]
        public void ThrowWhenFileIsNotFound()
        {
            // Arrange
            var imageService = new ImageService();

            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => imageService.GetImage("invalidPath"));
        }
    }
}
