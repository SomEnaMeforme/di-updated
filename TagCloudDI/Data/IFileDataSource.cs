namespace TagCloudDI.Data
{
    public interface IFileDataSource
    {
        public string[] GetWords(string filePath);
    }
}