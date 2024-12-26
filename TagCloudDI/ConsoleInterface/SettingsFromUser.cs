using McMaster.Extensions.CommandLineUtils;
using Spire.Doc.Documents;
using System.Drawing;
using TagCloudDI.CloudVisualize;

namespace TagCloudDI.ConsoleInterface
{
    public class SettingsFromUser
    {
        private readonly VisualizeSettings settings;
        public const string SizeSeparator = ";";
        public SettingsFromUser(VisualizeSettings settings)
        {
            this.settings = settings;
        }

        public string FontFamily
        {
            set
            {
                settings.FontFamily = new FontFamily(value);
            }
        }

        public string BackgroundColor
        {
            set
            {
                var color = Color.FromName(value);
                settings.BackgroundColor = color;
            }
        }

        public string ImageSize
        {
            set
            {
                var values = value.Split(SizeSeparator);
                var hasWidth = int.TryParse(values[0], out var width);
                var hasHeight = int.TryParse(values[1], out var height);
                settings.ImageSize = hasHeight && hasWidth ? new Size(width, height) : Size.Empty;
            }
        }

        public string[] WordColors
        {
            set
            {
                settings.WordColors = value.Select(c => Color.FromName(c)).ToArray();
            }
        }

        public string MaxFontSize
        {
            set
            {
                settings.MaxFontSize = int.TryParse(value, out var max) ? max : settings.MaxFontSize;
            }
        }

        public string MinFontSize
        {
            set
            {
                settings.MinFontSize = int.TryParse(value, out var min) ? min : settings.MinFontSize;
            }
        }
    }
}
