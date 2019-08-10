using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessing.Domain.Extensions
{
    public static class ByteExtensions
    {
        private static readonly byte[] bmp = Encoding.ASCII.GetBytes("BM");
        private static readonly byte[] gif = Encoding.ASCII.GetBytes("GIF");
        private static readonly byte[] png = {137, 80, 78, 71};
        private static readonly byte[] tiff = {73, 73, 42};
        private static readonly byte[] tiff2 = {77, 77, 42};
        private static readonly byte[] jpeg = {255, 216, 255, 224};
        private static readonly byte[] jpeg2 = {255, 216, 255, 225};
        private static readonly byte[] pdf = {37, 80, 68, 70};
        public static bool isImage(this byte[] file)
        {
            return bmp.SequenceEqual(file.Take(bmp.Length)) ||
                   gif.SequenceEqual(file.Take(gif.Length)) ||
                   png.SequenceEqual(file.Take(png.Length)) ||
                   tiff.SequenceEqual(file.Take(tiff.Length)) ||
                   tiff2.SequenceEqual(file.Take(tiff2.Length)) ||
                   jpeg.SequenceEqual(file.Take(jpeg.Length)) ||
                   jpeg2.SequenceEqual(file.Take(jpeg2.Length));
        }
        public static bool isPdf(this byte[] file)
        {
            return pdf.SequenceEqual(file.Take(pdf.Length));
        }
    }
}