using System.Drawing;

namespace TagCloudDI.CloudVisualize
{
    public class VisualizeSettings
    {
        private string defaultFontFamily = "Arial";

        public FontFamily FontFamily { get; set; }
        public Font Font { get; set; }
        public Color WordColor { get; set; }
        public Color BackgroundColor { get; set; }
        public Size ImageSize { get; set; }

        public VisualizeSettings()
        {
            FontFamily = new FontFamily(defaultFontFamily);
            Font = new Font(FontFamily, 15);
            WordColor = Color.Black;
            BackgroundColor = Color.Yellow;
        }
    }
}