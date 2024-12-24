using TagCloudDI.CloudVisualize;
using TagCloudDI.Data;

namespace TagCloudDI
{
    public class CloudCreator
    {
        private DataProvider dataProvider;
        private CloudVisualizer cloudVisualizer;
        public CloudCreator(DataProvider dataProvider, CloudVisualizer visualizer) 
        {
            this.dataProvider = dataProvider;
            cloudVisualizer = visualizer;
        }
        
        public string CreateTagCloud(string pathToFileWithWords)
        {
            var words = dataProvider.GetPreprocessedWords(pathToFileWithWords);
            return cloudVisualizer.CreateImage(words);
        }
    }
}