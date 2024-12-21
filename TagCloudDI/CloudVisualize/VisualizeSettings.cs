using System.Drawing;

namespace TagCloudDI.CloudVisualize
{
    public class VisualizeSettings
    {
        public FontFamily FontFamily { get; set; }
        public Font Font { get; set; }
        public Color WordColor { get; set; }
        public Color BackgroundColor { get; set; }
        public Size ImageSize { get; set; }

        public VisualizeSettings(string fontFamily)
        {
            FontFamily = new FontFamily(fontFamily);
        }
    }
}