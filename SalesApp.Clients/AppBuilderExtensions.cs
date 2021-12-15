using Avalonia.Controls;
using SalesApp.Clients.ViewModels;
using ShowcaseApplication.Core;

namespace SalesApp.Clients;
public static class AppBuilderExtensions
{
    public static T RegisterClientsModule<T>(this T builder, IServiceLocator serviceLocator) 
        where T : AppBuilderBase<T>, new() 
    {
        serviceLocator.ServiceCollection.AddScoped<ViewModelBase, ClientsViewModel>("ClientsViewModel");
        serviceLocator.ServiceCollection.AddScoped<ViewModelBase, AddUpdateClientViewModel>("AddUpdateClientViewModel");

        return builder;
    }
}
