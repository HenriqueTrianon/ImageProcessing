using ImageProcessing.Aplication.Services;
using ImageProcessing.Domain;
using ImageProcessing.Domain.Services;
using Restaurants.Infra.IoC;
using SimpleInjector;

namespace ImageProcessing.IoC
{
    public class ImageProcessingInjector:DependencyInjector<ImageProcessingInjector>
    {
        protected override Container ConfigureServices(Container container)
        {
            container.Register<IPdfService,PdfService>();
            container.Register<IQrCodeService,QrCodeService>();
            return container;
        }

        protected override Container ConfigureRepositories(Container container)
        {
            return container;
        }

        protected override Container ConfigureValidators(Container container)
        {
            return container;
        }
    }
}
