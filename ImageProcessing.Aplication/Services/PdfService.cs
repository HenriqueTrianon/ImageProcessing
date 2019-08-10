using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ImageProcessing.Domain.Extensions;
using ImageProcessing.Domain.Services;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;

namespace ImageProcessing.Aplication.Services
{
    public class PdfService:IPdfService
    {
        public IEnumerable<byte[]> ExtractImages(byte[] content)
        {
            if (!content.isPdf())
                return null;
            PdfDocument document = PdfReader.Open(new MemoryStream(content));
            document.Close();
            var imagens = new List<byte[]>();
            foreach (var item in document.Pages)
            {
                var recursos = item.Elements?.GetDictionary("/Resources");
                var xObjects = recursos?.Elements?.GetDictionary("/XObject");
                if (xObjects == null) continue;
                var items = xObjects.Elements.Values;
                imagens.AddRange(items.Select(i => (i as PdfReference)?.Value as PdfDictionary)
                        .Where(p => p != null && p.Elements.GetString("/Type") == "/XObject" && p.Elements.GetString("/Subtype") == "/Image")
                        .Select(i => i.Stream.Value)
                        .ToList());
            }
            return imagens;
        }
    }
}
