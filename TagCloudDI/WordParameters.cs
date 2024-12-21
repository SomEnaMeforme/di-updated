using System.Drawing;
using TagCloudDI.CloudVisualize;

namespace TagCloudDI
{
    public class WordParameters
    {
        public static int WordMaxHeight = 500;
        public static int WordMaxLetterWidth = 50;
        public Rectangle WordBorder { get; set; }
        public string Word {  get; }

        public Size WordBorderSize { get; }
        public WordParameters(string word, double frequency) 
        {
            Word = word;
            WordBorderSize = CalculateBorderSize(frequency);
        }

        public Size CalculateBorderSize(double frequency)
        {
            return new Size((int)(WordMaxLetterWidth * frequency * Word.Length), (int)(WordMaxHeight * frequency));
        }
    }
}