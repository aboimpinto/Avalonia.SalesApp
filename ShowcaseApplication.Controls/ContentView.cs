using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;

namespace ShowcaseApplication.Controls;

public class ContentView : ContentControl, IStyleable
{
    // Type IStyleable.StyleKey => typeof(ContentControl);

    public static readonly AvaloniaProperty HeaderProperty = 
        AvaloniaProperty.Register<ContentView, string>(nameof(Header));

    public static readonly AvaloniaProperty ButtonsProperty = 
        AvaloniaProperty.Register<ContentView, ObservableCollection<Button>>(nameof(Buttons));

    public ObservableCollection<Button> Buttons
    {
        get => (ObservableCollection<Button>)GetValue(ButtonsProperty);
        set => SetValue(ButtonsProperty, value);
    }

    public string Header 
    { 
        get => (string)GetValue(HeaderProperty); 
        set => SetValue(HeaderProperty, value);
    }

    public ContentView()
    {
        this.Header = "HEADER NOT SET";
        this.SetValue(ButtonsProperty, new ObservableCollection<Button>());
    }
}
