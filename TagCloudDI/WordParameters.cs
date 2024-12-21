using System.Drawing;

namespace TagCloudDI
{
    public class WordParameters
    {
        public string Word {  get; }
        public Rectangle WordBorder { get; private set; }

        public Size WordBorderSize { get; }
        public WordParameters(string word, double frequency) 
        {
            Word = word;
            WordBorderSize = CalculateBorderSize(frequency);
        }

        public Size CalculateBorderSize(double frequency)
        {

        }
    }
}