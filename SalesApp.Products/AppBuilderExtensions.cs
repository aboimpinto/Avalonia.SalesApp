using Avalonia.Controls;
using SalesApp.Products.ViewModels;
using ShowcaseApplication.Core;

namespace SalesApp.Products;
public static class AppBuilderExtensions
{
    public static T RegisterProductsModule<T>(this T builder, IServiceLocator serviceLocator) 
        where T : AppBuilderBase<T>, new() 
    {
        serviceLocator.ServiceCollection.AddScoped<ViewModelBase, ProductsViewModel>("ProductsViewModel");

        return builder;
    }
}
