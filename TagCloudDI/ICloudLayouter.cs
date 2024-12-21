using System.Drawing;

namespace TagCloudDI
{
    public interface ICloudLayouter
    {
        public Rectangle PutNextRectangle(Rectangle forInsertion);
    }
}