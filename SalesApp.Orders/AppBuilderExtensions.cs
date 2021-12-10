using Avalonia.Controls;
using SalesApp.Orders.ViewModels;
using ShowcaseApplication.Core;

namespace SalesApp.Orders;
public static class AppBuilderExtensions
{
    public static T RegisterOrdersModule<T>(this T builder, IServiceLocator serviceLocator) 
        where T : AppBuilderBase<T>, new() 
    {
        serviceLocator.ServiceCollection.AddScoped<ViewModelBase, OrdersViewModel>("OrdersViewModel");

        return builder;
    }
}
