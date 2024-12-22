using TagCloudDI.WordHandlers;

namespace TagCloudDI.Data
{
    public class DataProvider
    {
        private IFileDataSource source;
        private IEnumerable<IWordTransformer> transformers;
        private IEnumerable<IWordFilter> filters;
        public DataProvider(IFileDataSource dataSource, IEnumerable<IWordTransformer> transformers, IEnumerable<IWordFilter> filters) 
        {
            this.transformers = transformers;
            this.filters = filters;
            source = dataSource;
        }
        private string[] ReadData(IFileDataSource dataSource, string filePath)
        {
            return dataSource.GetWords(filePath);
        }

        private WordParameters[] PreprocessData(string[] words)
        {
            var preprocessedWords = words
                .Where(w => filters.All(f => f.Accept(w)))
                .Select(ApplyTransformers);
            var wordsWithFrequency = CalculateFrequency(preprocessedWords);
            return wordsWithFrequency.Select(kvp => new WordParameters(kvp.Key, kvp.Value)).ToArray();
        }

        private Dictionary<string, double> CalculateFrequency(IEnumerable<string> words)
        {
            var frequency = new Dictionary<string, double>();
            foreach (var word in words)
            {
                if (!frequency.ContainsKey(word))
                    frequency.Add(word, 0);
                frequency[word]++;
            }
            var maxFrequency = frequency.Max(kvp => kvp.Value);
            return frequency.ToDictionary(kvp => kvp.Key, kvp => kvp.Value / maxFrequency);
        }

        private string ApplyTransformers(string word)
        {
            foreach (var transformer in transformers)
            {
                word = transformer.Apply(word);
            }
            return word;
        }

        public WordParameters[] GetPreprocessedWords(string filePath)
        {
            var words = ReadData(source, filePath);
            return PreprocessData(words);
        }
    }
}
