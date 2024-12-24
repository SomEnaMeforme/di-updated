using Aspose.Words;

namespace TagCloudDI.Data
{
    internal class DocFileDataSource : IFileDataSource
    {
        public string GetData(string filePath)
        {
            var doc = new Document(filePath);
            return doc.GetText();
        }
    }
}
