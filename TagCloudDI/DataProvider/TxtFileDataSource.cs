namespace TagCloudDI.DataProvider
{
    public class TxtFileDataSource: IDataSource
    {
        private readonly string wordSeparator = "\n";
        private readonly string filePath;
        public TxtFileDataSource(string filePath)
        {
            this.filePath = filePath;
        }

        public string[] GetWords()
        {
            using var fileStream = new StreamReader(filePath);
            return fileStream.ReadToEnd().Split(wordSeparator);
        }
    }
}
