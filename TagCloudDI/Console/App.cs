using TagCloudDI.CloudVisualize;
using McMaster.Extensions.CommandLineUtils;

namespace TagCloudDI.ConsoleInterface
{
    public class App
    {
        private CommandLineApplication app;
        private CloudCreator creator;
        private CloudVisualizer visualizer;
        public App(CloudCreator creator, CloudVisualizer visualizer) 
        {
            this.creator = creator;
            this.visualizer = visualizer;
            app = new CommandLineApplication();

            app.HelpOption();
            app.Command("createTagCloud",ConfigureCreateCloudCommand);
            app.Command("change", ConfigureChangeImageParameterCommand);

            //var subject = app.Option("-s|--subject <SUBJECT>", "The subject", CommandOptionType.SingleValue);
            //subject.DefaultValue = "world";

            //var repeat = app.Option<int>("-n|--count <N>", "Repeat", CommandOptionType.SingleValue);
            //repeat.DefaultValue = 1;

            //app.OnExecute(() =>
            //{
            //    for (var i = 0; i < repeat.ParsedValue; i++)
            //    {
            //        Console.WriteLine($"Hello {subject.Value()}!");
            //    }
            //});
        }

        private void ConfigureCreateCloudCommand(CommandLineApplication cmd)
        {
            cmd.Description = "Create a tag cloud based on the transmitted text file";
            var filePath = cmd.Argument("file", "Path to file").IsRequired();
            cmd.OnExecute(() =>
            {
                var pathToImage = creator.CreateTagCloud(filePath.Value);
                Console.WriteLine("Path to cloud generation result: " + pathToImage);
            });
        }

        private void ConfigureChangeImageParameterCommand(CommandLineApplication cmd)
        {

        }

        public void Run()
        {
            while (true)
            {
                var args = Console.ReadLine();
                app.Execute(args.Split(' '));
            }
        }
    }
}
