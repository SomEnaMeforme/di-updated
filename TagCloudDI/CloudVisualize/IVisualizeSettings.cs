using System.Drawing;

namespace TagCloudDI.CloudVisualize
{
    public interface IVisualizeSettings
    {
        public Font Font { get; set; }
        public Color WordColor { get; set; }
        public Color BackgroundColor { get; set; }
        public Size ImageSize { get; set; }
    }
}