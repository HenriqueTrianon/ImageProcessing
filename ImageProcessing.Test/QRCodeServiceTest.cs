using System;
using System.IO;
using ImageProcessing.Domain;
using ImageProcessing.Domain.Extensions;
using ImageProcessing.Domain.Services;
using Xunit;
using Xunit.Abstractions;

namespace ImageProcessing.Test
{
    public class QRCodeServiceTest:TestBase
    {
        private IQrCodeService Service { get; }
        private IPdfService PdfService { get; }

        public QRCodeServiceTest(ITestOutputHelper output):base(output)
        {
            Service = container.GetInstance<IQrCodeService>();
            PdfService = container.GetInstance<IPdfService>();
        }
        [Theory]
        [InlineData("Images/QREncode01.jpg")]
        [InlineData("Images/QREncode02.jpg")]
        [InlineData("Images/QREncode03.jpg")]
        [InlineData("Images/QREncode04.jpg")]
        [InlineData("Images/QREncode05.jpg")]
        [InlineData("Images/QREncode06.jpg")]
        [InlineData("Images/QREncode07.jpg")]
        [InlineData("Images/QREncode08.jpg")]
        [InlineData("Images/QREncode09.png")]
        [InlineData("Images/QREncode10.jpg")]
        [InlineData("Images/QREncode11.jpg")]
        [InlineData("Images/QREncode12.jpg")]
        [InlineData("Images/QREncode13.jpg")]
        [InlineData("Images/QREncode14.jpg")]

        public void QrCodeServiceReadTest(string path)
        {
            var conteudo = File.ReadAllBytes($"{Environment.CurrentDirectory}\\{path}");
            var retorno = "";
            if (conteudo.isPdf())
            {
                foreach (var item in PdfService.ExtractImages(conteudo))
                {
                    retorno = Service.ReadQrCode(item);
                    if (!string.IsNullOrEmpty(retorno))
                        break;
                }
            }
            if (conteudo.isImage())
            {
                retorno = Service.ReadQrCode(conteudo);
            }
            Assert.False(string.IsNullOrEmpty(retorno));
            output.WriteLine(retorno);
        }
        [Theory]
        [InlineData("Exemplo 1")]
        [InlineData("Informacao 2")]
        public void gerarQrCodeTeste(string informacao)
        {
            var imagem = Service.GetQrCode(informacao);
            Assert.NotNull(imagem);
            File.WriteAllBytes($@"C:\temp\{informacao}.png", imagem);
        }
    }
}
