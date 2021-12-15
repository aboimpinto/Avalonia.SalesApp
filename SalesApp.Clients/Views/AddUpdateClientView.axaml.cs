using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SalesApp.Clients.Views
{
    public partial class AddUpdateClientView : UserControl
    {
        public AddUpdateClientView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}