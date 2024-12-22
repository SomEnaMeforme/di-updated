using System.Drawing;
using System.Transactions;
using TagCloudDI.CloudVisualize;
using TagCloudDI.Data;

namespace TagCloudDI
{
    public class CloudCreator
    {
        private DataProvider dataProvider;
        private ICloudLayouter layouter;
        private CloudVisualizer cloudVisualizer;
        public CloudCreator(DataProvider dataProvider, CloudVisualizer visualizer, ICloudLayouter cloudLayouter) 
        {
            this.dataProvider = dataProvider;
            this.layouter = cloudLayouter;
            cloudVisualizer = visualizer;
        }
        
        public string CreateTagCloud(string pathToFileWithWords)
        {
            var words = dataProvider.GetPreprocessedWords(pathToFileWithWords);
            // pathToFileWithImage = ".\\WorldCloud.png";
            foreach (var word in words)
            {
                word.WordBorder = layouter.PutNextRectangle(word.WordBorderSize);
            }
            return cloudVisualizer.CreateImage(words);
        }
    }
}