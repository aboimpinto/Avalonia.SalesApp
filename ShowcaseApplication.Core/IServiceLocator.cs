using System;
using Microsoft.Extensions.DependencyInjection;

namespace ShowcaseApplication.Core
{
    public interface IServiceLocator
    {
        ServiceCollection ServiceCollection { get; }

        ServiceProvider ServiceProvider { get; }
    }
}
