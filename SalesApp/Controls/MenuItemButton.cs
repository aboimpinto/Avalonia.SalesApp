using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Styling;
using Material.Icons;

namespace SalesApp.Controls
{
    public class MenuItemButton : RadioButton, IStyleable
    {
        Type IStyleable.StyleKey => typeof(ToggleButton);

        public static readonly AvaloniaProperty KindProperty = 
            AvaloniaProperty.Register<MenuItemButton, MaterialIconKind>(nameof(Kind));

        public MaterialIconKind Kind
        {
            get => (MaterialIconKind)GetValue(KindProperty);
            set => SetValue(KindProperty, value);
        }

        public MenuItemButton()
        {
            this.Kind = MaterialIconKind.Widgets;
        }
    }
}
