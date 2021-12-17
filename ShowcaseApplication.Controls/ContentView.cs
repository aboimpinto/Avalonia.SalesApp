using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;

namespace ShowcaseApplication.Controls;

public class ContentView : ContentControl, IStyleable
{
    Type IStyleable.StyleKey => typeof(ContentControl);

    public static readonly AvaloniaProperty ButtonsProperty = 
        AvaloniaProperty.Register<ContentView, ContentControl>(nameof(Buttons));

    public object Buttons
    {
        get => (ContentControl)GetValue(ButtonsProperty);
        set => SetValue(ButtonsProperty, value);
    }

    public ContentView()
    {
    }
}
