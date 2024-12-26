using TagCloudDI.CloudVisualize;
using McMaster.Extensions.CommandLineUtils;
using System.Drawing;
using System.Diagnostics;

namespace TagCloudDI.ConsoleInterface
{
    public class App
    {
        private CommandLineApplication app;
        private CloudCreator creator;
        private VisualizeSettings settings;
        public App(CloudCreator creator, VisualizeSettings visualizeSettings) 
        {
            this.creator = creator;
            settings = visualizeSettings;
            app = new CommandLineApplication<App>();

            app.HelpOption();
            app.Command("createTagCloud", ConfigureCreateCloudCommand);
            app.Command("configure", ConfigureChangeImageParameterCommand);
        }

        private void ConfigureCreateCloudCommand(CommandLineApplication cmd)
        {
            cmd.Description = "Create a tag cloud based on the transmitted text file";
            cmd.HelpOption();
            var filePath = cmd.Argument("file", "Path to file").IsRequired();
            cmd.OnExecute(() =>
            {
                if (File.Exists(filePath.Value))
                {
                    var pathToImage = creator.CreateTagCloud(filePath.Value);
                    Console.WriteLine("Path to cloud generation result: " + pathToImage);
                    OpenImage(pathToImage);
                }
                else Console.WriteLine("Try read non existed file");
                
            });
        }

        private void OpenImage(string pathToImage)
        {
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(pathToImage) { UseShellExecute = true };
            p.Start();
        }

        private void ConfigureChangeImageParameterCommand(CommandLineApplication cmd)
        {
            var sizeSeparator = ";";
            cmd.Description = "Configure settings for tag cloud visualization";
            cmd.HelpOption();
            var font = cmd.Option("-f|--font <FONT>", "The font for words", CommandOptionType.SingleValue);
            var fontSizeMin = cmd.Option("-fs-min|--fontSize <MIN>", "The min for font size", CommandOptionType.SingleValue);
            var fontSizeMax = cmd.Option("-fs-max|--fontSize <MAX>", "The max for font size", CommandOptionType.SingleValue);
            var wordsColor = cmd.Option("-wc|--word-color <COLOR_NAMES>", "The words colors", CommandOptionType.MultipleValue);
            var backgroundColor = cmd.Option("-bg|--background-color <COLOR_NAME>", "The background color", CommandOptionType.SingleValue);
            var imageSize = cmd.Option($"-i|--imageSize <WIDTH{sizeSeparator}HEIGHT>", "The size for image in pixel", CommandOptionType.SingleValue);
            cmd.OnExecute(() =>
            {
                if (font.HasValue())
                    settings.FontFamily = new FontFamily(font.Value());
                if (fontSizeMin.HasValue())
                {
                    settings.MinFontSize = int.TryParse(fontSizeMin.Value(), out var min) ? min : settings.MinFontSize;
                }
                if (fontSizeMax.HasValue())
                {
                    settings.MaxFontSize = int.TryParse(fontSizeMax.Value(), out var max) ? max : settings.MaxFontSize;
                }
                if (imageSize.HasValue())
                {
                    var values = imageSize.Value().Split(sizeSeparator);
                    var hasWidth = int.TryParse(values[0], out var width);
                    var hasHeight = int.TryParse(values[1], out var height);
                    settings.ImageSize = hasHeight && hasWidth ? new Size(width, height) : Size.Empty;
                }
                if (wordsColor.HasValue())
                {
                    settings.WordColors = wordsColor.Values.Select(c => Color.FromName(c)).ToArray();
                }
                if (backgroundColor.HasValue())
                {
                    var color = Color.FromName(backgroundColor.Value());
                    settings.BackgroundColor = color;
                }
            });
        }

        public void Run()
        {
            while (true)
            {
                var args = Console.ReadLine();
                try
                {
                    app.Execute(args.Split(' '));
                }
                catch (UnrecognizedCommandParsingException e)
                {
                    Console.WriteLine(e.Message);
                }               
            }
        }
    }
}
