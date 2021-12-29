using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;
using Avalonia.Xaml.Interactivity;

namespace SalesApp.Behaviors
{
    /// <summary>
    /// This behavior only make sense for Linux dut to the fact on this platform is not possible yet to center the window into the screen.
    /// </summary>
    public class CenterScreenBehavior : Behavior<Window>
    {
        protected override async void OnAttached()
        {
            base.OnAttached();

            if (OperatingSystem.IsWindows())
            {
                // Not need for windows
            }

            if (this.AssociatedObject == null)
            {
                return;
            }

            // var scale = this.AssociatedObject.PlatformImpl?.DesktopScaling ?? 1.0;
            // var pOwner = this.AssociatedObject.Owner?.PlatformImpl;
            // if (pOwner != null)
            // {
            //     scale = pOwner.DesktopScaling;
            // }
            // var rect = new PixelRect(
            //     PixelPoint.Origin,
            //     PixelSize.FromSize(this.AssociatedObject.ClientSize, scale));

            // if (this.AssociatedObject.WindowStartupLocation == WindowStartupLocation.CenterScreen)
            // {
            //     var screen = this.AssociatedObject.Screens.ScreenFromPoint(pOwner?.Position ?? this.AssociatedObject.Position);
            //     if (screen == null)
            //     {
            //         return;
            //     }
            //     this.AssociatedObject.Position = screen.WorkingArea.CenterRect(rect).Position;
            // }

            Screen? screen = null;
            while (screen == null) 
            {
                await Task.Delay(1);
                screen = this.AssociatedObject.Screens.ScreenFromVisual(this.AssociatedObject);
            }

            if (this.AssociatedObject.WindowStartupLocation == WindowStartupLocation.CenterScreen)
            {
                var x = (int)Math.Floor(screen.Bounds.Width / 2 - this.AssociatedObject.Bounds.Width / 2);
                var y = (int)Math.Floor(screen.Bounds.Height / 2 - (this.AssociatedObject.Bounds.Height + 30) / 2);

                this.AssociatedObject.Position = new PixelPoint(x, y);
            }
        }
    }
}