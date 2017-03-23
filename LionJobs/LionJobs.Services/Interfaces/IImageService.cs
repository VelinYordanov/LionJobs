using System.Drawing;
using System.IO;

namespace LionJobs.Services.Interfaces
{
    public interface IImageService
    {
        byte[] ImageToByteArray(Image imageIn);

        string ByteArrayToImageUrl(byte[] byteArrayIn);

        Image GetImage(string path);

        byte[] GetByteArrayFromStream(Stream inputStream);
    }
}