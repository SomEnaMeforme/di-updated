using System.Diagnostics;
using System.Text;

namespace TagCloudDI.MyStem
{
    public static class MyStem
    {
        public static string AnalyseWords(string words)
        {
            var directory = ".\\MyStem";
            var inputFile = Path.Combine(directory, "input.txt");
            var outputFile = Path.Combine(directory, "output.txt");
            var mySteam = Path.Combine(directory, "mystem.exe");
            using (var writer = new StreamWriter(inputFile))
            {
                writer.Write(words);
            }
            var arguments = string.Format("-in {0} {1}", inputFile, outputFile);
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = mySteam,
                    Arguments = arguments,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                }
            };
            process.Start();
            process.WaitForExit();
            using var reader = new StreamReader(outputFile, Encoding.UTF8);
            return reader.ReadToEnd();
        }
    }
}
