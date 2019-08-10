using System;

namespace ImageProcessing.Domain
{
    public interface IQrCodeService
    {
        byte[] GetQrCode(string message, int width = 400, int height = 400);
        string ReadQrCode(byte[] content);
    }
}
