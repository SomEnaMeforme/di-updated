using TagCloudDI.CloudVisualize;
using TagCloudDI.Data;

namespace TagCloudDI
{
    public class CloudCreator
    {
        private DataProvider dataProvider;
        private CloudVisualizer cloudVisualizer;
        private readonly DefaultImageSaver imageSaver;
        public CloudCreator(DataProvider dataProvider, CloudVisualizer visualizer) 
        {
            this.dataProvider = dataProvider;
            cloudVisualizer = visualizer;
            imageSaver = new DefaultImageSaver();
        }
        
        public string CreateTagCloud(string pathToFileWithWords)
        {
            var words = dataProvider.GetPreprocessedWords(pathToFileWithWords);
            var image = cloudVisualizer.CreateImage(words);
            return imageSaver.SaveImage(image);
        }
    }
}