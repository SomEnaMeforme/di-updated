﻿using Autofac;
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
            builder.RegisterType<BoredSpeechPartFilter>().As<IWordFilter>();
            builder.RegisterType<RemoveEmptyWords>().As<IWordFilter>();
            builder.RegisterType<CircularCloudLayouter>().As<ICloudLayouter>();
            builder.RegisterType<CloudCreator>();
            builder.RegisterType<CloudVisualizer>();
            builder.RegisterType<DataProvider>();
            builder.RegisterType<RandomWordColorDistributor>().As<IWordColorDistributor>();
            builder.Register<Func<string, IFileDataSource>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();
                return p => ctx.ResolveKeyed<IFileDataSource>(p);
            });
            builder.RegisterType<TxtFileDataSource>().Keyed<IFileDataSource>(".txt");
            builder.RegisterType<DocFileDataSource>().Keyed<IFileDataSource>(".doc");
            builder.RegisterType<DocFileDataSource>().Keyed<IFileDataSource>(".docx");
            builder.RegisterType<App>().SingleInstance();
            builder.RegisterType<VisualizeSettings>().SingleInstance();

            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<App>();
                app.Run();
            }
        }
    }
}
