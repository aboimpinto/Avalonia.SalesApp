using Avalonia.Controls;
using Avalonia.Styling;

namespace ShowcaseApplication.Controls;

public class ContentView : ContentControl, IStyleable
{
    Type IStyleable.StyleKey => typeof(ContentControl);

    public ContentView()
    {
    }
}
