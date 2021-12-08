using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ShowcaseApplication.Core
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddScoped<TService, TMetadata>(this IServiceCollection services, TMetadata metadata) where TService : class
        {
            return services.AddScoped<TService, TService, TMetadata>(metadata);
        }

        public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services, TImplementation implementation, string context) where TService : class
                                                                                                                                                                where TImplementation : class, TService
        {
            return services.AddScoped<TService, TImplementation, string>(implementation, context);
        }

        public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services, Func<IServiceProvider, TImplementation> implementationFactory, string context) where TService : class
                                                                                                                                                                                               where TImplementation : class, TService
        {
            return services.AddScoped<TService, TImplementation, string>(implementationFactory, context);
        }

        public static IServiceCollection AddScoped<TService, TImplementation, TMetadata>(this IServiceCollection services, Func<IServiceProvider, TImplementation> implementationFactory, TMetadata metadata) where TService : class
                                                                                                                                                                                                              where TImplementation : class, TService
        {
            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            if (implementationFactory == null)
                throw new ArgumentNullException(nameof(implementationFactory));

            return services.AddScoped<TService>(s => s.GetServices<IServiceMetadata<TService, TMetadata>>()
                                                      .OfType<IServiceMetadata<TService, TImplementation, TMetadata>>()
                                                      .First(x => Equals(x.Metadata, metadata))
                                                      .CachingImplementationFactory(s)) // This registration ensures that only one instance is created in the scope
                           .AddScoped((Func<IServiceProvider, IServiceMetadata<TService, TMetadata>>)(s => new ServiceMetadata<TService, TImplementation, TMetadata>(metadata, implementationFactory)));
        }

        public static IServiceCollection AddScoped<TService, TImplementation, TMetadata>(this IServiceCollection services, TImplementation implementation, TMetadata metadata) where TService : class
                                                                                                                                                                               where TImplementation : class, TService
        {
            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            return services.AddScoped<TService>(s => s.GetServices<IServiceMetadata<TService, TMetadata>>()
                                                      .OfType<IServiceMetadata<TService, TImplementation, TMetadata>>()
                                                      .First(sm => Equals(sm.Metadata, metadata))
                                                      .CachingImplementationFactory(s))
                           .AddScoped<IServiceMetadata<TService, TMetadata>>(s => new ServiceMetadata<TService, TImplementation, TMetadata>(metadata, ss => implementation));
        }

        public static IServiceCollection AddScoped<TService, TImplementation, TMetadata>(this IServiceCollection services, TMetadata metadata) where TService : class
                                                                                                                                               where TImplementation : class, TService
        {
            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            services.TryAddTransient<TImplementation>();
            if (typeof(TService) != typeof(TImplementation))
                services.AddScoped<TService>(s => s.GetServices<IServiceMetadata<TService, TMetadata>>()
                                                   .OfType<IServiceMetadata<TService, TImplementation, TMetadata>>()
                                                   .First(sm => Equals(sm.Metadata, metadata))
                                                   .CachingImplementationFactory(s));

            return services.AddScoped<IServiceMetadata<TService, TMetadata>>(s => new ServiceMetadata<TService, TImplementation, TMetadata>(metadata, ss => ss.GetService<TImplementation>()));
        }

        public static IServiceCollection AddScoped<TService>(this IServiceCollection services, string context) where TService : class
        {
            return services.AddScoped<TService, string>(context);
        }

        public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services, string context) where TService : class
                                                                                                                                where TImplementation : class, TService
        {
            return services.AddScoped<TService, TImplementation, string>(context);
        }

        public static TService GetService<TService>(this IServiceProvider serviceProvider, string context)
        {
            return context == null ? serviceProvider.GetService<TService, string>() : serviceProvider.GetService<TService, string>(m => m == context);
        }

        public static TService GetService<TService, TMetadata>(this IServiceProvider serviceProvider, Func<TMetadata, bool> predicate = null)
        {
            var relevantMetadata = serviceProvider.GetServices<IServiceMetadata<TService, TMetadata>>();
            var selectedMetadata = predicate != null ? relevantMetadata.FirstOrDefault(sm => predicate(sm.Metadata)) : relevantMetadata.FirstOrDefault();
            return selectedMetadata != null ? selectedMetadata.CachingImplementationFactory(serviceProvider) : default;
        }

        public static IEnumerable<TService> GetServices<TService, TMetadata>(this IServiceProvider serviceProvider, Func<TMetadata, bool> predicate = null)
        {
            var metadata = serviceProvider.GetServices<IServiceMetadata<TService, TMetadata>>();

            return (predicate != null ? metadata.Where(sm => predicate(sm.Metadata)) : metadata).Select(sm => sm.CachingImplementationFactory(serviceProvider));
        }

        private interface IServiceMetadata<TService, out TMetadata>
        {
            Func<IServiceProvider, TService> CachingImplementationFactory { get; }

            TMetadata Metadata { get; }
        }

        private interface IServiceMetadata<TService, TImplementation, out TMetadata> : IServiceMetadata<TService, TMetadata> where TService : class
                                                                                                                             where TImplementation : class, TService
        {
            new Func<IServiceProvider, TImplementation> CachingImplementationFactory { get; }
        }

        private class ServiceMetadata<TService, TImplementation, TMetadata> : IServiceMetadata<TService, TImplementation, TMetadata> where TService : class
                                                                                                                                     where TImplementation : class, TService
        {
            private TImplementation _cachedImplementation;

            Func<IServiceProvider, TService> IServiceMetadata<TService, TMetadata>.CachingImplementationFactory => CachingImplementationFactory;

            public Func<IServiceProvider, TImplementation> CachingImplementationFactory { get; }

            public TMetadata Metadata { get; }

            public ServiceMetadata(TMetadata metadata, Func<IServiceProvider, TImplementation> implementationFactory)
            {
                if (implementationFactory == null)
                {
                    throw new ArgumentNullException(nameof(implementationFactory));
                }

                Metadata = metadata;
                CachingImplementationFactory = s => _cachedImplementation ?? (_cachedImplementation = implementationFactory(s));
            }
        }
    }
}
