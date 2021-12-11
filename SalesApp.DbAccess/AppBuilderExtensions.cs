using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShowcaseApplication.Core;

namespace SalesApp.DbAccess
{
    public static class AppBuilderExtensions
    {
        public static T RegisterDbAccessModule<T>(this T builder, IServiceLocator serviceLocator) 
            where T : AppBuilderBase<T>, new() 
        {
            serviceLocator.ServiceCollection.AddTransient<SalesDbContext, SalesDbContext>();

            var dbContext = serviceLocator.ServiceProvider.GetService<SalesDbContext>();
            if (dbContext != null)
            {
                dbContext.Database.Migrate();
            }

            return builder;
        }
    }
}
