using Microsoft.Extensions.DependencyInjection;

namespace ShowcaseApplication.Core
{
    public class ServiceLocator : IServiceLocator
    {
        private ServiceProvider _serviceProvider;

        public IServiceCollection ServiceCollection { get; }

        public ServiceProvider ServiceProvider 
        {
            get 
            {
                if (this._serviceProvider == null)
                {
                    this._serviceProvider = this.ServiceCollection.BuildServiceProvider();
                }

                return this._serviceProvider;
            }
        }

        public ServiceLocator()
        {
            this.ServiceCollection = new ServiceCollection();
            this.ServiceCollection.AddSingleton<IServiceLocator>(this);
        }
    }
}
