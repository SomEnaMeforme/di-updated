namespace TagCloudDI.Data
{
    public enum SpeechPart
    {
        Verb,
        Noun,
        Adjective,
        Adverb,
        Numb,
        Pronoun,
        Preposition,
        Interjection,
        Part,
        Conjunction
    }
    public class WordInfo
    {
        private static Dictionary<string, SpeechPart> getSpeechPart = new Dictionary<string, SpeechPart>
        {
            {"S", SpeechPart.Noun},
            { "V", SpeechPart.Verb},
            {"A",  SpeechPart.Adjective},
            {"ADV", SpeechPart.Adverb },
            {"PR", SpeechPart.Preposition},
            {"SPRO", SpeechPart.Pronoun},
            {"APRO", SpeechPart.Pronoun},
            {"NUM", SpeechPart.Numb},
            {"PART",  SpeechPart.Part},
            {"INTJ", SpeechPart.Interjection },
            {"CONJ", SpeechPart.Conjunction },
        };

        public SpeechPart SpeechPart { get; }
        public string InitialForm { get; set; }

        public WordInfo(SpeechPart speechPart, string initialForm)
        {
            SpeechPart = speechPart;
            InitialForm = initialForm;
        }

        public static WordInfo[] ParseText(string text)
        {
            var analysedWords = MyStem.MyStem.AnalyseWords(text).Split('\n');
            var result = new List<WordInfo>();
            foreach (var word in analysedWords)
            {
                result.Add(new WordInfo(GetSpeechPart(word), GetInitForm(word)));
            }
            return result.ToArray();
        }

        private static SpeechPart GetSpeechPart(string analysedWord)
        {
            var start = analysedWord.IndexOf('=') + 1;
            var end = analysedWord.IndexOf(',');
            if (start > 0 && end - start > 0)
            {
                if (getSpeechPart.TryGetValue(analysedWord.Substring(start, end - start), out var part))
                    return part;
            }
            return SpeechPart.Interjection;
        }

        private static string GetInitForm(string analysedWord)
        {
            var start = analysedWord.IndexOf('{') + 1;
            var end = analysedWord.IndexOf('=');
            var initialForm = start > 0 && end - start > 0 ? analysedWord.Substring(start, end - start) : "";
            return initialForm;
        }
    }
}
