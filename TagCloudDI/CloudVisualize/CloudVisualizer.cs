using System.Drawing;

namespace TagCloudDI.CloudVisualize
{
    public class CloudVisualizer
    {
        private VisualizeSettings settings;
        private readonly ICloudLayouter layouter;
        private readonly IWordColorDistributor distributor;


        public CloudVisualizer(VisualizeSettings settings, ICloudLayouter cloudLayouter, IWordColorDistributor distributor)
        {
            this.settings = settings;
            layouter = cloudLayouter;
            this.distributor = distributor;
        }

        public Bitmap CreateImage((string Word, double Frequency)[] source)
        {
            var words = LayoutWords(source).ToArray();
            var tmpImageSize = CalculateImageSize(words);
            words = PlaceCloudInImage(words, tmpImageSize);
            using var image = new Bitmap(tmpImageSize.Width, tmpImageSize.Height);
            using var graphics = Graphics.FromImage(image);

            graphics.Clear(settings.BackgroundColor);

            for (var i = 0; i < words.Length; i++)
            {
                var currentWord = words[i];
                var font = new Font(settings.FontFamily, currentWord.FontSize);
                var color = distributor.GetColor(settings.WordColors);
                graphics.DrawRectangle(new Pen(color), currentWord.WordBorder);
                graphics.DrawString(currentWord.Word, font, new SolidBrush(color), currentWord.WordBorder);
            }
            var resizedImage = new Bitmap(image, settings.ImageSize);
            return resizedImage;
        }

        private IEnumerable<WordParameters> LayoutWords((string Word, double Frequency)[] words)
        {
            var g = Graphics.FromImage(new Bitmap(1, 1));
            foreach (var word in words)
            {
                var fontSize = Math.Max((float)(settings.MaxFontSize * word.Frequency), settings.MinFontSize);
                var wordSize = g.MeasureString(word.Word, new Font(settings.FontFamily, fontSize));
                var wordSizeInt = new Size((int)Math.Ceiling(wordSize.Width), (int)Math.Ceiling(wordSize.Height));
                var border = layouter.PutNextRectangle(wordSizeInt);
                yield return new WordParameters(word.Word, border, fontSize);
            }
            layouter.Clear();
        }

        private WordParameters[] PlaceCloudInImage(WordParameters[] words, Size tmpImageSize)
        {
            var deltaForX = CalculateDeltaForMoveByAxis(words, r => r.Left, r => r.Right, tmpImageSize.Width);
            var deltaForY = CalculateDeltaForMoveByAxis(words, r => r.Top, r => r.Bottom, tmpImageSize.Height);
            foreach (var word in words)
            {
                word.MoveBorderToNewLocation(new Point(word.WordBorder.Left + deltaForX, word.WordBorder.Y + deltaForY));
            }
            return words;
        }

        private int CalculateDeltaForMoveByAxis(
            WordParameters[] words,
            Func<Rectangle, int> selectorForMin,
            Func<Rectangle, int> selectorForMax,
            int sizeByAxis)
        {
            if (words.Length == 0) return 0;
            var minByAxis = words.Min(w => selectorForMin(w.WordBorder));
            var maxByAxis = words.Max(w => selectorForMax(w.WordBorder));
            return minByAxis < 0
                ? -1 * minByAxis
                : maxByAxis > sizeByAxis
                ? sizeByAxis - maxByAxis
                : 0;
        }

        private Size CalculateImageSize(WordParameters[] words)
        {
            var width = words.Max(w => w.WordBorder.Right) - words.Min(w => w.WordBorder.Left);
            var height = words.Max(w => w.WordBorder.Bottom) - words.Min(w => w.WordBorder.Top);
            var sizeForRectangles = Math.Max(width, height);
            return new Size(sizeForRectangles, sizeForRectangles);
        }
    }
}