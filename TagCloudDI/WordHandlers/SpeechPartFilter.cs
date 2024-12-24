using TagCloudDI.Data;
using static TagCloudDI.MyStem.MyStem;

namespace TagCloudDI.WordHandlers
{
    public class SpeechPartFilter : IWordFilter
    {
        private HashSet<SpeechPart> speechPartForInclude = new();
        public bool Accept(WordInfo word)
        {
            return speechPartForInclude.Contains(word.SpeechPart);
        }
    }
}
