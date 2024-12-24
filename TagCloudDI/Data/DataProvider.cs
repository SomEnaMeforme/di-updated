using TagCloudDI.WordHandlers;

namespace TagCloudDI.Data
{
    public class DataProvider
    {
        private Func<string, IFileDataSource> getSource;
        private IEnumerable<IWordTransformer> transformers;
        private IEnumerable<IWordFilter> filters;
        public DataProvider(Func<string, IFileDataSource> factory, IEnumerable<IWordTransformer> transformers, IEnumerable<IWordFilter> filters) 
        {
            this.transformers = transformers;
            this.filters = filters;
            getSource = factory;
        }
        private string[] ReadAndParseData(IFileDataSource dataSource, string filePath)
        {
            var text = dataSource.GetData(filePath);
            var punctuation = text
                .Where(char.IsPunctuation)
                .Distinct()
                .ToArray();
            var words = text.Split()
                .Select(x => x.Trim(punctuation))
                .Where(x => x.Length > 0)
                .ToArray();
            return words;
        }

        private (string Word, double Frequency)[] PreprocessData(string[] words)
        {
            var wordInfos = WordInfo.ParseText(string.Join(" ", words));
            var preprocessedWords = wordInfos
                .Where(w => filters.All(f => f.Accept(w)))
                .Select(ApplyTransformers);
            var wordsWithFrequency = CalculateFrequency(preprocessedWords);
            return wordsWithFrequency.Select(kvp => (Word : kvp.Key, Frequency : kvp.Value)).ToArray();
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

        private string ApplyTransformers(WordInfo word)
        {
            foreach (var transformer in transformers)
            {
                word = transformer.Apply(word);
            }
            return word.InitialForm;
        }

        public (string Word, double Frequency)[] GetPreprocessedWords(string filePath)
        {
            var source = getSource(Path.GetExtension(filePath));
            var words = ReadAndParseData(source, filePath);
            return PreprocessData(words);
        }
    }
}
