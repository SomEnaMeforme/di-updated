using McMaster.Extensions.CommandLineUtils;
using TagCloudDI.CloudVisualize;

namespace TagCloudDI.ConsoleInterface
{
    public interface IOptionForChange<T>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CommandOptionType OptionType { get; set; }

        public void Handle(T value, VisualizeSettings settings);
        // var a = cmd.GetOptions().Select(o => o.ValueName).ToArray();
    }
}
