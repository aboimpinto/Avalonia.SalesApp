using System;
using Microsoft.Extensions.DependencyInjection;

namespace ShowcaseApplication.Core
{
    public interface IServiceLocator
    {
        IServiceCollection ServiceCollection { get; }

        ServiceProvider ServiceProvider { get; }
    }
}
