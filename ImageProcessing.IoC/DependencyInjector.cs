using SimpleInjector;

namespace Restaurants.Infra.IoC
{
    public abstract  class DependencyInjector<T> where T: new()
    {
        
        public Container Initialize(Container container = null)
        {
            return ConfigureValidators(ConfigureRepositories(ConfigureServices(container ?? new Container())));
        }
        protected abstract Container ConfigureServices(Container container);
        protected abstract Container ConfigureRepositories(Container container);
        protected abstract Container ConfigureValidators(Container container);
        
    }
}
