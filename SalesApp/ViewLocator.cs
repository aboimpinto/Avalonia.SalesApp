using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using ShowcaseApplication.Core;

namespace SalesApp
{
    public class ViewLocator : IDataTemplate
    {
        public IControl Build(object data)
        {
            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var assembly = data.GetType().Assembly.FullName;
            var type = Type.GetType($"{name}, {assembly}");

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }
            else
            {
                return new TextBlock { Text = "Not Found: " + name };
            }
        }

        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}