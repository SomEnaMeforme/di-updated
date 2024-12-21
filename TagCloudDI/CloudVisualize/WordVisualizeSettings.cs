using System.Drawing;

namespace TagCloudDI.CloudVisualize
{
    public class WordVisualizeSettings
    {
        public FontFamily FontFamily { get; set; }
        public Font Font { get; set; }
        public Color WordColor { get; set; }
        public Rectangle WordBorder { get; private set; }
        public WordVisualizeSettings(string fontFamily) 
        { 
            FontFamily = new FontFamily(fontFamily);
        }
    }
}
