using System;
using Microsoft.Extensions.DependencyInjection;

namespace ShowcaseApplication.Core
{
    public class ServiceLocator : IServiceLocator
    {
        public ServiceCollection ServiceCollection { get; }

        public ServiceProvider ServiceProvider => this.ServiceCollection.BuildServiceProvider();

        public ServiceLocator()
        {
            this.ServiceCollection = new ServiceCollection();

            this.ServiceCollection.AddSingleton<IServiceLocator>(this);
        }
    }
}
