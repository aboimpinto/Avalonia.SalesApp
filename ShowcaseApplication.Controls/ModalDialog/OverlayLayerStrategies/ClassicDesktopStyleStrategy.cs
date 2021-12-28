using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Primitives;

namespace ShowcaseApplication.Controls.OverlayLayerStrategies
{
    public class ClassicDesktopStyleStrategy : IOverlayLayerStrategy
    {
        public OverlayLayer GetOverlayLayer()
        {
            var classicDesktopStyleApp = Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime;

            Window activeWindow = null;

            foreach (var item in classicDesktopStyleApp?.Windows)
            {
                if (item.IsActive)
                {
                    activeWindow = item;
                    break;
                }
            }

            //Fallback, just in case
            if (activeWindow == null)
            {
                activeWindow = classicDesktopStyleApp?.MainWindow;
            }

            var ol = OverlayLayer.GetOverlayLayer(activeWindow);
            if (ol == null)
            {
                throw new InvalidOperationException();
            }
            
            return ol;
        }

        public bool IsValid()
        {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime)
            {
                return true;
            }

            return false;
        }
    }
}
