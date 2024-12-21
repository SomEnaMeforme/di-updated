using System.Drawing;
using TagCloudDI.WordHandlers;

namespace TagCloudDI.CloudVisualize
{
    public class CloudVisualizer
    {
        private VisualizeSettings settings;
        public CloudVisualizer(VisualizeSettings settings)
        {
            this.settings = settings;
        }
        public string CreateImage(IEnumerable<WordParameters> source)
        {
            throw new NotImplementedException();
        }
    }
}