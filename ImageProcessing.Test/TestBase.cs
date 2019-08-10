using System;
using System.Collections.Generic;
using System.Text;
using ImageProcessing.IoC;
using Restaurants.Infra.IoC;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Xunit;
using Xunit.Abstractions;

namespace ImageProcessing.Test
{
    public class TestBase :  IDisposable
    {
        protected readonly Scope scope;
        protected readonly Container container;
        protected readonly ITestOutputHelper output;
        public TestBase(ITestOutputHelper output)
        {
            ImageProcessingInjector injector= new ImageProcessingInjector();
            container = injector.Initialize(container);
            scope = AsyncScopedLifestyle.BeginScope(container);
            this.output = output;
        }
        public void Dispose()
        {
            scope.Dispose();
        }
    }
}
