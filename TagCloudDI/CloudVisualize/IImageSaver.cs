using System.Drawing;

namespace TagCloudDI.CloudVisualize
{
    public interface IImageSaver
    {
        public string SaveImage(Bitmap image, string filename);
    }
}
