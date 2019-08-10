
using System.IO;
using ImageProcessing.Domain;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using ZXing;
using ZXing.QrCode;

namespace ImageProcessing.Aplication.Services
{
    public class QrCodeService : IQrCodeService
    {
        public byte[] GetQrCode(string message, int width = 400, int height = 400)
        {
            var write = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Height = height,
                    Width = width
                }
            };
            var ms = new MemoryStream();
            var pixelData = write.Write(message);
            using (var image = Image.LoadPixelData<Rgba32>(pixelData.Pixels, width, height))
            {
                image.Save(ms, PngFormat.Instance);
            }
            return ms.ToArray();

        }

        public string ReadQrCode(byte[] content)
        {
            var bitmap = Image.Load(content);
            var reader = new ZXing.ImageSharp.BarcodeReader<Rgba32>();
            var result = reader.Decode(bitmap);
            return result?.Text ?? "";
        }
    }
}
