using Avalonia;
using Avalonia.Controls;

namespace ShowcaseApplication.Controls
{
    public class IconButton : Button
    {
        public static readonly AvaloniaProperty KindProperty = 
            AvaloniaProperty.Register<Button, Material.Icons.MaterialIconKind>(nameof(Kind));

        public Material.Icons.MaterialIconKind Kind
        { 
            get => (Material.Icons.MaterialIconKind)GetValue(KindProperty);
            set => SetValue(KindProperty, value);
        }
    }
}
