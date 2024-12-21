using System.Drawing;
using TagCloudDI.WordHandlers;

namespace TagCloudDI.CloudVisualize
{
    public class CloudVisualizer
    {
        private IVisualizeSettings settings;
        public CloudVisualizer(IVisualizeSettings settings)
        {
            this.settings = settings;
        }
        public string CreateImage(IEnumerable<IWordParameters> source)
        {
            throw new NotImplementedException();
        }
    }
}