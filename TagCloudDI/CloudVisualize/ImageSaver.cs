﻿using System.Drawing.Imaging;
using System.Drawing;

namespace TagCloudDI.CloudVisualize
{
    internal class ImageSaver
    {
        private ImageFormat format = ImageFormat.Png;

        public void SaveImage(Bitmap image, string? filePath = null)
        {
            var rnd = new Random();
            filePath ??= Path.Combine(Path.GetTempPath(), $"tagCloud{rnd.Next()}.{FormatToString()}");
            image.Save(filePath, format);
        }

        private string? FormatToString()
        {
            return new ImageFormatConverter().ConvertToString(format)?.ToLower();
        }
    }
}