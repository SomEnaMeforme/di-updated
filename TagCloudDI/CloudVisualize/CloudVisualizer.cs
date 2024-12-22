using System.Drawing;

namespace TagCloudDI.CloudVisualize
{
    public class CloudVisualizer
    {
        private VisualizeSettings settings;
        private readonly ImageSaver imageSaver;
        private readonly Size defaultSizeForImage = new Size(500, 500);

        public CloudVisualizer(VisualizeSettings settings)
        {
            this.settings = settings;
            imageSaver = new ImageSaver();
        }

        public string CreateImage(IEnumerable<WordParameters> source, string? filePath = null)
        {
            var words = source.ToArray();
            var tmpImageSize = CalculateImageSize(words);
            words = PlaceCloudInImage(words, tmpImageSize);
            using var image = new Bitmap(tmpImageSize.Width, tmpImageSize.Height);
            using var graphics = Graphics.FromImage(image);

            graphics.Clear(settings.BackgroundColor);

            var brush = new SolidBrush(settings.WordColor);

            for (var i = 0; i < words.Length; i++)
            {
                var nextWord = words[i];
                graphics.DrawString(nextWord.Word, settings.Font, brush, nextWord.WordBorder);
            }
            var resizedImage = new Bitmap(image, tmpImageSize);//settings.ImageSize);
            return imageSaver.SaveImage(resizedImage, filePath);
        }

        private WordParameters[] PlaceCloudInImage(WordParameters[] words, Size tmpImageSize)
        {
            var deltaForX = CalculateDeltaForMoveByAxis(words, r => r.Left, r => r.Right, tmpImageSize.Width);
            var deltaForY = CalculateDeltaForMoveByAxis(words, r => r.Top, r => r.Bottom, tmpImageSize.Height);
            foreach (var word in words)
            {
                word.WordBorder = new Rectangle(new Point(word.WordBorder.Left + deltaForX, word.WordBorder.Y + deltaForY), word.WordBorder.Size);
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
            var sizeForRectangles = Math.Max(Math.Max(width, height), defaultSizeForImage.Width);
            return new Size(sizeForRectangles, sizeForRectangles);
        }
    }
}