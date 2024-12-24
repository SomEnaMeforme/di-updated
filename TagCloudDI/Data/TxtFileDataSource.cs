using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace TagCloudDI.Data
{
    public class TxtFileDataSource: IFileDataSource
    {
        public string GetData(string filePath)
        {
            using var fileStream = new StreamReader(filePath);
            return fileStream.ReadToEnd();
        }
    }
}
