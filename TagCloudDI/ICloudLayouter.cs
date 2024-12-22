using System.Drawing;

namespace TagCloudDI
{
    public interface ICloudLayouter
    {
        public Rectangle PutNextRectangle(Size forInsertion);
    }
}