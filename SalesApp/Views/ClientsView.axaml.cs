using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SalesApp.Views
{
    public partial class ClientsView : UserControl
    {
        public ClientsView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}