using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Domain.Services
{
    public interface IPdfService
    {
        IEnumerable<byte[]> ExtractImages(byte[] content);

    }
}
