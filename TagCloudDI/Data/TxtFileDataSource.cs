namespace TagCloudDI.Data
{
    public class TxtFileDataSource: IFileDataSource
    {
        private readonly string wordSeparator = "\n";

        public string[] GetWords(string filePath)
        {
            using var fileStream = new StreamReader(filePath);
            return fileStream.ReadToEnd().Split(wordSeparator);
        }
    }
}
