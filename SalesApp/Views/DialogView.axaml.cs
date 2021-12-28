using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SalesApp.Views
{
    public partial class DialogView : UserControl
    {
        public DialogView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}