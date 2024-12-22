using Autofac;
using Autofac.Extensions.DependencyInjection;
using McMaster.Extensions.CommandLineUtils;
using TagCloudDI.CloudVisualize;
using TagCloudDI.ConsoleInterface;
using TagCloudDI.Data;
using TagCloudDI.WordHandlers;
using TagsCloudVisualization.CloudLayouter;

namespace TagCloudDI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LowerCaseTransformer>().As<IWordTransformer>();
            builder.RegisterType<CircularCloudLayouter>().As<ICloudLayouter>();
            builder.RegisterType<CloudCreator>().As<CloudCreator>();
            builder.RegisterType<CloudVisualizer>().As<CloudVisualizer>();
            builder.RegisterType<DataProvider>();
            builder.RegisterType<TxtFileDataSource>().As<IFileDataSource>();
            builder.RegisterType<App>().SingleInstance();
            builder.RegisterType<VisualizeSettings>();

            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<App>();
                app.Run();
            }
        }
    }
}
